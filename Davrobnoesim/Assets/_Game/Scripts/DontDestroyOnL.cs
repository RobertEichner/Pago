using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnL : MonoBehaviour
{
   private void Awake()
   {
      DontDestroyOnLoad(gameObject);
   }
}
