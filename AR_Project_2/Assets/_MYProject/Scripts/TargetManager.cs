using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using Random = UnityEngine.Random;


public class TargetsManager : MonoBehaviour
{
    [SerializeField] ARPlaneManager m_ARPlaneManager;
    [SerializeField] ARRaycastManager m_ARRaycastManager;
    
    [SerializeField] ObjectSpawner m_ObjectSpawner;


    //returns hit reasults
    List<ARRaycastHit> hits = new List<ARRaycastHit>();


    Vector2 screenCenter;
    bool isSpawned = false;
    [SerializeField] bool m_RequireHorizontalUpSurface;

    ARPlane lastPlane = null;

    public void TrySpawnTarget()
    {

        bool s = m_ARRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

        ARPlane arPlane = null;
        if (hits.Count > 0)
        {
            arPlane = hits[0].trackable as ARPlane;
        }
        if (arPlane == null) return;
        if (lastPlane == arPlane) return;

        if (m_RequireHorizontalUpSurface && arPlane.alignment != PlaneAlignment.HorizontalUp)
            return;

        float randomX = Random.Range(arPlane.centerInPlaneSpace.x - arPlane.extents.x / 2, arPlane.centerInPlaneSpace.x + arPlane.extents.x / 2);
        float randomY = Random.Range(arPlane.centerInPlaneSpace.y - arPlane.extents.y / 2, arPlane.centerInPlaneSpace.y + arPlane.extents.y / 2);


        Vector3 spawnRandomPos = arPlane.transform.TransformPoint(new Vector3(randomX, 0, randomY));


        if (s)
        {
            m_ObjectSpawner.TrySpawnObject(spawnRandomPos, arPlane.normal);
            lastPlane = arPlane;
            isSpawned = true;
            Debug.Log("isSpawned = true;");
        }

    }


    void Start()
    {
        //register to events
       // GameManager.Instance.OnTargetHit += ResetSpawn;
        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
    }
    void ResetSpawn(int obj)
    {
        isSpawned = false;
    }


    void Update()
    {
        if (!isSpawned) TrySpawnTarget();
    }
}
