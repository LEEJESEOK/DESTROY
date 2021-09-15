using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text Scoretext;
    int totalscore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int Enenscore)
    {
        totalscore += Enenscore;
        Scoretext.text = totalscore.ToString();
    }
}
