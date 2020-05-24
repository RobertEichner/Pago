using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGold : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private PlayerGold playerGold = null;

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
        text.text = $"{Mathf.Ceil(currentGold)}/{Mathf.Ceil(maxGold)}";
    }
}
