using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }


        Instance = this;
    }

    public event Action <int> OnTargetHit;

    public void TargetHit(int targetValue)
    {
        OnTargetHit?.Invoke(targetValue);
    }

}
