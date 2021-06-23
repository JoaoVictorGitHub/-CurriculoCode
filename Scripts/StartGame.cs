using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject menuCanvas;

    public bool remoteMenu = false;

    public void GameStart()
    {
        SceneManager.LoadScene("SampleScene");

    }

    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("GameQuit");
    }

    public void ReturnToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    void MenuRemote()
    {
        if (remoteMenu == true)
        {
            menuCanvas.SetActive(true);
        }
        else if (remoteMenu == false)
        {
            menuCanvas.SetActive(false);
        }
    }

    private void Update()
    {


        if (!menuCanvas.activeSelf && Input.GetKeyDown(KeyCode.M))
        {
            menuCanvas.SetActive(true);
            remoteMenu = true;
        }
        else if (menuCanvas.activeSelf && Input.GetKeyDown(KeyCode.M))
        {
            menuCanvas.SetActive(false);
            remoteMenu = false;
        }

        MenuRemote();

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuScene"))
        {
            menuCanvas.SetActive(true);
        }
    }


}
