using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public static StartAudio Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
                
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // DontDestroyOnLoad(gameObject);

        if(SceneManager.GetActiveScene().name == "GameScene")
        {
            Destroy(gameObject);            
        }
    }

    


}
