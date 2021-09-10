using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PostM : MonoBehaviour
{

    PostProcessVolume Vol;
    Bloom bloom;
    Vignette Vig;
    float currtime;

    // Start is called before the first frame update
    void Start()
    {
        Vol = gameObject.GetComponent<PostProcessVolume>();
       Vol.profile.TryGetSettings<Bloom>(out bloom);
       Vol.profile.TryGetSettings<Vignette>(out Vig);
        
    }

    // Update is called once per frame
    void Update()
    {
        currtime += Time.deltaTime;

        if(currtime >= 2)
        {
           


        }

    }
}
