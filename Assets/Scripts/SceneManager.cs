using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frameee
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            pauseScreen.SetActive(true);
        }
    }
}
