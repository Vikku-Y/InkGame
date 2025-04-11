using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public GameObject PauseScreen;
    public Button NextButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen.SetActive(true);
            NextButton.interactable = false;
        }
    }

    public void ExitPause()
    {
        PauseScreen.SetActive(false);
        NextButton.interactable = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
