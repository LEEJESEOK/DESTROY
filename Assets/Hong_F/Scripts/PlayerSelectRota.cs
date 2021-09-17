using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerSelectRota : MonoBehaviour
{
    Vector3 dir;
    int num = 2;

    // Update is called once per frame
    void Update()
    {
        if (num % 4 == 0)
        {
            dir = new Vector3(0, 0, -1);
            if (dir == new Vector3(0, 0, -1))
            {
                PlayerPrefs.SetInt("CS", 0);
            }
        }
        else if (num % 4 == 1)
        {
            dir = new Vector3(1, 0, 0);
            if (dir == new Vector3(1, 0, 0))
            {
                PlayerPrefs.SetInt("CS", 1);
            }
        }
        else if (num % 4 == 2)
        {
            dir = new Vector3(0, 0, 1);
            if (dir == new Vector3(0, 0, 1))
            {
                PlayerPrefs.SetInt("CS", 2);
            }
        }
        else if (num % 4 == 3)
        {
            dir = new Vector3(-1, 0, 0);
            if (dir == new Vector3(-1, 0, 0))
            {
                PlayerPrefs.SetInt("CS", 3);
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }

    public void ClikRight()
    {
        AudioSource button = GameObject.Find("AudioManagers").GetComponent<AudioSource>();

        // if (num == 0) num = 4;
        // else num--;

        // 4 : max of num
        num = (num - 1 + 4) % 4;

        button.Play();
    }

    public void ClikLeft()
    {
        AudioSource button = GameObject.Find("AudioManagers").GetComponent<AudioSource>();

        // if (num == 4) num = 0;
        // else num++;

        num = (num + 1) % 4;

        button.Play();
    }

    public void Select()
    {
        AudioSource button = GameObject.Find("AudioManagers").GetComponent<AudioSource>();

        button.Play();

        SceneManager.LoadScene("GameScene");
    }

    public void Back()
    {
        AudioSource button = GameObject.Find("AudioManagers").GetComponent<AudioSource>();

        button.Play();

        SceneManager.LoadScene("IntroScene");
    }
}
