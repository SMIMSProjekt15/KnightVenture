using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int score = 0;
    public string playerName = null;

    public int highScore = 0;
    public int maxLifes = 3;
    private int lifes;

    private bool gameStarted = true;

    void Start()
    {
        if (gameStarted == false)
        {
            gameStarted = true;
            Debug.Log("Spiel wurde gestartet!");
            SceneManager.LoadScene(0);

        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void startGame()
    {
        score = 0;
        playerName = "Lara";
        //NamenSpeichern.instance.myInputField.text
        lifes = maxLifes;
        SceneManager.LoadScene(1);

    }

    public void neustart()
    {
        lifes = maxLifes;
        SceneManager.LoadScene(0);
    }

    public void scoreboard()
    {
        SceneManager.LoadScene(4);
    }
    public void DecreaseHealth()
    {
        --lifes;
        Debug.Log($"Lifes {lifes}");
        if(lifes == 0)
        {
            SceneManager.LoadScene("Lose", LoadSceneMode.Single);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;

        if (score > highScore)
        {
            highScore = score;
            print("New high score: " + highScore);
        }
    }

    public class PlayerScore
    {
        public string playerName1;
        public int playerScore;
    }

    public static List<PlayerScore> playerScores = new List<PlayerScore>();
    public List<Text> playerTexts;

    public void AddPlayerScore()
    {
        string playerName1 = playerName;
        int score1 = score;

        PlayerScore newScore = new PlayerScore
        {
            playerName1 = playerName,
            playerScore = score1
        };

        playerScores.Add(newScore);
        playerScores = playerScores.OrderByDescending(p => p.playerScore).Take(5).ToList(); // Sortieren und auf Top 10 beschränken
    }

    public void UpdatePlayerTexts()
    {
        for (int i = 0; i < playerTexts.Count; i++)
        {
            if (i < playerScores.Count)
            {
                playerTexts[i].text = $"{playerScores[i].playerName1}: {playerScores[i].playerScore}";
            }
            else
            {
                playerTexts[i].text = "";
            }

        }
    }
}



    