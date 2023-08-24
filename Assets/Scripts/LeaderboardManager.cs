using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{

    public static LeaderboardManager instance;

    private void Awake()
    {
        instance = this;
        print("hello, world");
    }

    public class PlayerScore
    {
        public string playerName;
        public int score;
    }

    public static List<PlayerScore> playerScores = new List<PlayerScore>();
    public List<Text> playerTexts;

    public void AddPlayerScore()
    {
        string playerName = NamenSpeichern.instance.myInputField.text;
        int score = GameManager.instance.score;

        PlayerScore newScore = new PlayerScore
        {
            playerName = playerName,
            score = score
        };

        playerScores.Add(newScore);
        playerScores = playerScores.OrderByDescending(p => p.score).Take(5).ToList(); // Sortieren und auf Top 10 beschr�nken
    }

   public  void UpdatePlayerTexts()
    {
        for (int i = 0; i < playerTexts.Count; i++)
        {
            if (i < playerScores.Count)
            {
                playerTexts[i].text = $"{playerScores[i].playerName}: {playerScores[i].score}";
            }
            else
            {
                playerTexts[i].text = "";
            }

        }
    }
}
    
