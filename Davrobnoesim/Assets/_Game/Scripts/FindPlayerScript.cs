using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FindPlayerScript : MonoBehaviour
{
   private CinemachineVirtualCamera vcam;
   private void Awake()
   {
      TryGetComponent(out vcam);
      Transform playerPos = GameObject.FindWithTag("Player").transform;
      vcam.Follow = playerPos;
   }
}
