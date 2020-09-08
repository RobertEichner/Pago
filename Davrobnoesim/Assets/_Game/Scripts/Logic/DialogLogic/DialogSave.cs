using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Saves/Dialog")]
public class DialogSave : ScriptableObject
{
   [SerializeField] private State initialStartState = null;

   public State StartState { get; set; } = null;
   
   private void OnEnable()
   {
      StartState = initialStartState;
   }
}
