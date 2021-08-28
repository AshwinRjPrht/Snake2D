using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI score;
    private int points = 0;
    private void Awake()
    {
        score = GetComponent<TextMeshProUGUI>();
    }
    public void IncreaseScore(int increment)
    {
        points += increment;
        RefreshUI();
    }

    public void ResetScore(int increment)
    {
        points = increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        score.text = "Score: " + points;
    }
}
