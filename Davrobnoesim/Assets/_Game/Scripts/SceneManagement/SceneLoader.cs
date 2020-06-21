using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ButtonWeiter()
    {
        Debug.Log("Button, der das Spiel weiterlaufen lässt");
        SceneManager.LoadScene(0);

        
    }
    public void ButtonOptionen() {
        Debug.Log("Button, der die Optionen öffnet");
        SceneManager.LoadScene(1);
    
    }

    public void ButtonClose() {
        Debug.Log("Button, der das Spiel speichert und beendet");
        //Save und close implementieren
    }

    public void ButtonLoadGame() {
        SceneManager.LoadScene(3);
    }

    public void ButtonNewGame()
    {
        SceneManager.LoadScene(4);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}
