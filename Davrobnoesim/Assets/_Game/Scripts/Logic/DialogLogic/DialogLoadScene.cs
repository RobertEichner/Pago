using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Dialog/LoadScene")]
public class DialogLoadScene : State
{
    [SerializeField] private int sceneNumber = 0;

    public override void StoryEvent()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
