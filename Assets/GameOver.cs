using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{

public Text gameOver;
public Movement player;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    if(player.dead == true){

        gameOver.text = "Game Over" ;
    }
    }
}
