using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Text healthText;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
        {
            health = 0;
            SceneManager.LoadScene(2);

        }


        healthText.text = "Health: " + health;


    }
}