using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGold : MonoBehaviour, IChangeGold
{
   [SerializeField] private int currentGold = 0;
   [SerializeField] private int maxGold = 1000;

   public event EventHandler<GoldChangedArgs> OnGoldChanged; 
   
   
   public int CurrentGold
   {
      get => currentGold;
      set
      {
         currentGold = Mathf.Clamp(value, 0, maxGold);
         OnGoldChanged?.Invoke(this, new GoldChangedArgs
         {
            CurrentGold = currentGold,
            MaxGold = maxGold
         });
         
      }
   }

   public int MaxGold => maxGold;

   public class GoldChangedArgs : EventArgs
   {
      public int CurrentGold{ get; set;}
      public int MaxGold { get; set;}
   }

   public void ChangeGold(int amount)
   {
      CurrentGold += amount;
   }
}
