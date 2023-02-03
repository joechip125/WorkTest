using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
   public string playerName;
   public int playerScore;
   public int playerRank;

   public PlayerData(string name, int score)
   {
      playerName = name;
      playerScore = score;
   }
}


[Serializable]
public class MultiData
{
   public List<PlayerData> playerData = new();
}