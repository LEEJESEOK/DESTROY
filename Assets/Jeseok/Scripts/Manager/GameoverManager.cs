using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverManager : MonoBehaviour
{
    public static GameoverManager instance;


    AudioSource button;

    public Text scoreText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<AudioSource>();

        scoreText.text = "" + ScoreManager.instance.currentScore;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickRetry()
    {
        button.Play();
        SceneManager.LoadScene("SelectScene");
    }

    public void onClickExit()
    {
        button.Play();
        Application.Quit();
    }
}
