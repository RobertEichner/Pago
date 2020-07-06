﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderSceneLoader : MonoBehaviour 
{

    [SerializeField] private int scene;
    [SerializeField] private float x, y;
    private static int levelToLoad;
    private static float posX, posY;


    public Animator animator;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelToLoad = scene;
            posX = x;
            posY = y;
            
            animator.SetTrigger("fadeOut");
        }
    }

    public void OnFadeComplete()
    {

        SceneManager.LoadScene(levelToLoad);
         
    }

    private void OnLevelWasLoaded()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector2(posX, posY);
    }
}