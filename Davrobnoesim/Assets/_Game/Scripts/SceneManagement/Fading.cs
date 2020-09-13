using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour
{
    private static float nx, ny = 0;
    private int nscene = 0;
    private GameObject player = null;
    private Animator anim = null;
    private PlayerMovement pm = null;
    private Action onDeath = null;

    private void Awake()
    {
        TryGetComponent(out anim);
    }

    void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
 
    void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
 
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        if (scene.buildIndex == nscene)
        {
            player = GameObject.FindWithTag("Player");
            player.transform.position = new Vector2(nx, ny);
            pm.SetCanMove(true);
        }
    }
    
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(nscene);
        onDeath?.Invoke();
    }

    public void StartTrans(float x, float y, GameObject player, int scene, Action onDeath)
    {
        this.onDeath = onDeath;
        player.TryGetComponent(out pm);
        pm.SetCanMove(false);
        nscene = scene;
        nx = x;
        ny = y;
        this.player = player;
        anim.SetTrigger("fadeOut");
    }
}
