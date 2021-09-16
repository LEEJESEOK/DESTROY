using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;


    public int currentScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        UIManager.instance.UpdateScore();
    }
}
