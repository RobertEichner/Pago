using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialog/RichySpezial")]
public class RichySpezial : State
{
    [SerializeField] private string nameRichy = "Richy";
    [SerializeField] private string nameNaiad = "Naiad";
    [SerializeField] private Sprite richySpriteBack = null;
    [SerializeField] private string triggerNaiad = "trigger";
    
    private GameObject richy;
    private GameObject naiad;
    
    public override void StoryEvent()
    {
        richy = GameObject.Find(nameRichy);
        naiad = GameObject.Find(nameNaiad);

        richy.GetComponent<SpriteRenderer>().sprite = richySpriteBack;
        naiad.GetComponent<Animator>().SetTrigger(triggerNaiad);

    }
}
