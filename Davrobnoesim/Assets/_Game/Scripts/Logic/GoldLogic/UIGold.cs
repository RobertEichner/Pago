﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIGold : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private PlayerGold playerGold = null;

    private void Awake()
    {
        TryGetComponent<TextMeshProUGUI>(out text);
    }
    
    private void OnEnable()
    {
        UpdateGoldUI(playerGold.CurrentGold, playerGold.MaxGold);
        playerGold.OnGoldChanged += HandleGoldChange;
    }

    private void OnDisable()
    {
        playerGold.OnGoldChanged -= HandleGoldChange;
    }

    private void HandleGoldChange(object sender, PlayerGold.GoldChangedArgs args)
    {
        UpdateGoldUI(args.CurrentGold, args.MaxGold);
    }

    private void UpdateGoldUI(int currentGold, int maxGold)
    {
        text.text = currentGold.ToString();
    }
}