using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private int score;
    private TMP_Text scoreText;

    private void Start()
    {
        //GameManager.Instance.OnTargetHit += UpdateScore;
    }

    private void UpdateScore(int addedValue)
    {
        score += addedValue;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {

    }
}
