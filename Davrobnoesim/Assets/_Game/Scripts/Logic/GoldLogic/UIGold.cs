using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIGold : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private PlayerGold playerGold = null;

    private void Awake()
    {
        TryGetComponent<TextMeshProUGUI>(out text);
    }
    
    private void Reset()
    {
        if (!playerGold)
            playerGold = FindObjectOfType<PlayerGold>();
    }
    
    private void OnEnable()
    {
        UpdateGoldUI(playerGold.CurrentGold, playerGold.MaxGold);
        playerGold.OnGoldChanged += HandleGoldChange;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        playerGold.OnGoldChanged -= HandleGoldChange;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void HandleGoldChange(object sender, PlayerGold.GoldChangedArgs args)
    {
        UpdateGoldUI(args.CurrentGold, args.MaxGold);
    }

    private void UpdateGoldUI(int currentGold, int maxGold)
    {
        text.text = currentGold.ToString();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateGoldUI(playerGold.CurrentGold, playerGold.MaxGold);
    }

}
