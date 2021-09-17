using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploAudio : MonoBehaviour
{
       public Grenade grenade;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void sound()
    {
        grenade = GetComponent<Grenade>();

    }

    


}
