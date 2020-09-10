using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ButtonWeiter()
    {
        int index = SceneManager.GetActiveScene().buildIndex +1;
        if (index > SceneManager.sceneCountInBuildSettings)
            index = SceneManager.sceneCountInBuildSettings;
        ButtonLoadGame(index);
    }

    public void ButtonLoadGame(int index) {
        SceneManager.LoadScene(index);
    }
    
    public void ButtonExit()
    {
        Application.Quit();
    }
}
