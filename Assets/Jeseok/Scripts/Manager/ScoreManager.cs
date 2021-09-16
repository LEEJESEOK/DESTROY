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
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void initScoreManager()
    {
        currentScore = 0;
    }

    public void AddScore(int score)
    {
        if (GameManager.instance.gameState != GameManager.GameState.Play)
            return;
            
        currentScore += score;
        UIManager.instance.UpdateScore();
    }
}
