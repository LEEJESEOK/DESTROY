using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerSelectRota : MonoBehaviour
{



    PlayerOnOff on;

    // Start is called before the first frame update
    void Start()
    {
    }

    Vector3 dir;
    int num;

    // Update is called once per frame
    void Update()
    {

        on = FindObjectOfType<PlayerOnOff>();

        if (num % 4 == 0)
        {
            dir = new Vector3(0, 0, -1);
            if (dir == new Vector3(0, 0, -1))
            {
                print("ť��");
                PlayerPrefs.SetInt("CS", 0);
            }

        }
        else if (num % 4 == 1)
        {
            dir = new Vector3(1, 0, 0);
            if (dir == new Vector3(1, 0, 0))
            {
                print("��Ʈ");
                PlayerPrefs.SetInt("CS", 1);

            }
        }
        else if (num % 4 == 2)
        {
            dir = new Vector3(0, 0, 1);
            if (dir == new Vector3(0, 0, 1))
            {
                print("���̾Ƹ��");
                PlayerPrefs.SetInt("CS", 2);

            }
        }
        else if (num % 4 == 3)
        {
            dir = new Vector3(-1, 0, 0);
            if (dir == new Vector3(-1, 0, 0))
            {
                print("��");
                PlayerPrefs.SetInt("CS", 3);

            }
        }




        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);


    }

    public void ClikRight()
    {
        AudioSource button = GameObject.Find("AudioManagers").GetComponent<AudioSource>();

        if (num == 0) num = 4;
        else num--;
        button.Play();
    }

    public void ClikLeft()
    {
        AudioSource button = GameObject.Find("AudioManagers").GetComponent<AudioSource>();

        if (num == 4) num = 0;
        else num++;
        button.Play();

    }

    public void Select()
    {
        AudioSource button = GameObject.Find("AudioManagers").GetComponent<AudioSource>();

        button.Play();

        SceneManager.LoadScene("GameScene");

        //���Ӿ����� �Ѿ�� 
        // ������ ĳ���͸�Ȱ��ȭ
    }

    public void Back()
    {
        AudioSource button = GameObject.Find("AudioManagers").GetComponent<AudioSource>();

        button.Play();


        SceneManager.LoadScene("IntroScene");

    }



}
