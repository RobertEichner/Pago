using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Dialog/CarlEndChecker")]
public class CarlDialogFIrst : State
{
    [SerializeField] private int sceneToLoad = 0;
    [SerializeField] private Quest[] questsToFinish = null;
    public override void StoryEvent()
    {
        foreach (var quest in questsToFinish)
        {
            if(!quest.IsDone)
                return;
        }

        ClearNextStates();
        SceneManager.LoadScene(sceneToLoad);

    }
}
