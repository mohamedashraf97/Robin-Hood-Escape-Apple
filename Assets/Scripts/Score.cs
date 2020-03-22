using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public static int score;
    public Arrow arrow;

    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }
    void Update()
        {
            if(arrow.hitTarget == true){

                score += 1;
            }
            scoreText.text = "Apples: " + score.ToString();
        }

    }

