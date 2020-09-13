using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnExit : MonoBehaviour
{
   [SerializeField] private Canvas can = null;
   [SerializeField] private bool activateOnEnter = false;
   private void OnTriggerExit2D(Collider2D other)
   {
      can.enabled = false;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (activateOnEnter)
         can.enabled = true;
      activateOnEnter = false;
   }
}
