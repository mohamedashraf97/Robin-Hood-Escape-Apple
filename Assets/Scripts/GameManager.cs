using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Arrow_Emitter;
    public GameObject Arrow;
    //public GameObject Enemy_Emitter;
    public GameObject Enemy;
    public float Arrow_Forward_Force;
    public float Enemy_Forward_Force;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float minTime;
    public float timeDecrease;
    public Animator anim;
    public Movement player;
    public bool attack;
    public Vector2 side;

    void Update()
    {
        anim = player.GetComponent<Animator>();
        if(Input.GetButtonDown("Fire1") && player.dead == false){ 
            
            Shoot(); 
            
            anim.SetTrigger("Attack");
            attack = true ;
            anim.SetFloat("Speed",0.0f);
            }
            else
            {
                //anim.SetBool("Attack",false);
                attack = false ;
               
            }

        Vector2 pos = Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(0f, 1f), 1));
        Vector2 pos1 = Camera.main.ViewportToWorldPoint(new Vector2(1, Random.Range(0f, 1f)));

        
        if (timeBtwSpawns <= 0 && player.dead == false )
        {
            
            GameObject Temporary_Enemy_Handler;
            GameObject Temporary_Enemy_Handler1;
            Temporary_Enemy_Handler = Instantiate(Enemy,pos, Quaternion.identity) as GameObject;
            Temporary_Enemy_Handler1 = Instantiate(Enemy,pos1, Quaternion.identity) as GameObject;
            Rigidbody2D Temporary_RigidBody;
            Rigidbody2D Temporary_RigidBody1;
            Temporary_RigidBody = Temporary_Enemy_Handler.GetComponent<Rigidbody2D>();
            Temporary_RigidBody1 = Temporary_Enemy_Handler1.GetComponent<Rigidbody2D>();
            Temporary_RigidBody.AddForce(transform.up * Enemy_Forward_Force, ForceMode2D.Impulse);
            Temporary_RigidBody1.AddForce(side , ForceMode2D.Impulse);
            Destroy(Temporary_Enemy_Handler, 9.0f);
            Destroy(Temporary_Enemy_Handler1, 9.0f);
            
            timeBtwSpawns = startTimeBtwSpawns;
            if (startTimeBtwSpawns > minTime) {
                startTimeBtwSpawns -= timeDecrease;
            }
            
        }
        else {
               
               timeBtwSpawns -= Time.deltaTime;

            }
    }

    void Shoot(){


            GameObject Temporary_Arrow_Handler;
            Temporary_Arrow_Handler = Instantiate(Arrow,Arrow_Emitter.transform.position,Arrow_Emitter.transform.parent.rotation) as GameObject;

            Rigidbody2D Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Arrow_Handler.GetComponent<Rigidbody2D>();
 
            Temporary_RigidBody.AddForce(Arrow_Emitter.transform.up * Arrow_Forward_Force, ForceMode2D.Impulse);
            Temporary_Arrow_Handler.transform.Rotate(Vector3.left * 180);
            
 
 
            Destroy(Temporary_Arrow_Handler, 4.0f);


    }
}
