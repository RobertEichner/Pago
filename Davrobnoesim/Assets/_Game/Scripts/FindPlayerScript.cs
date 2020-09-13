using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class FindPlayerScript : MonoBehaviour
{
   private CinemachineVirtualCamera vcam;

   private void Awake()
   {
      TryGetComponent(out vcam);
      Transform playerPos = GameObject.FindWithTag("Player").transform;
      vcam.Follow = playerPos;
      vcam.LookAt = null;
   }

   private void OnEnable()
   {
      SceneManager.sceneLoaded += OnLevelLoaded;
   }

   private void OnDisable()
   {
      SceneManager.sceneLoaded -= OnLevelLoaded;
   }

   private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
   {
      vcam.enabled = false;
      vcam.enabled = true;
   }
}
