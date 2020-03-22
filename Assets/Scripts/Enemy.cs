﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);     

        }
        else if (collision.gameObject.tag == "Arrow")
        {   
             Score.score++;
            Destroy(gameObject);     

        }

    }
}
