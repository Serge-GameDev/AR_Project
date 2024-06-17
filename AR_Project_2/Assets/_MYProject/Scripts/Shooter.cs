using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour
{
    [SerializeField] Rigidbody[] bullets;
    [SerializeField] Transform camT, spawnPointT;
    [SerializeField] float launchForce = 500, directionOffset = 3;
    int bulletIndex = 0;
    public int BulletIndex
    {
        get => bulletIndex;
        set
        {
            if (value <= 0)
                return;
            bulletIndex = value;
            BulletIndex = bulletIndex;
        }
    }


    public void Shoot()
    {
        Rigidbody bulletRb = Instantiate(bullets[bulletIndex], spawnPointT.position, spawnPointT.rotation);
        Vector3 shootingDirection = camT.transform.forward + new Vector3(0, directionOffset, 0);
        bulletRb.AddForce(shootingDirection * launchForce, ForceMode.Impulse);
    }
}
