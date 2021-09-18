using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startbutton()
    {
        Buttonsound();
        SceneManager.LoadScene("SelectScene");
    }

    public void Exitbutton()
    {
        Buttonsound();
        Application.Quit();
    }

    public void Buttonsound()
    {
        AudioSource button = GetComponent<AudioSource>();
        button.Play();
    }
}
