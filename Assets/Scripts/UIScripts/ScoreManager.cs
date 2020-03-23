using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int Score;
    private TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
        Score = 0;
    }

    void Update()
    {
        text.text = "Score: " + Score;
    }

    public void AddPointsToScore(int points)
    {
        Score += points;
    }
}
