using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{
    private  float movSpeed = 18f;
    public bool dead;
    public Rigidbody2D rb;
    public Camera cam;
    public Animator anim;
    public GameManager gameManager;
    public GameObject RestartButton;

    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      if(gameManager.attack== false)
      {
          anim.SetFloat("Speed",movement.sqrMagnitude);
      }
   
      mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

   
    void FixedUpdate()
    {
        if(dead == false)
        {
         RestartButton.SetActive(false);
         rb.MovePosition(rb.position + movement * movSpeed * Time.fixedDeltaTime);
         Vector2 pos = transform.position;
         //Vector3 pos = cam.WorldToScreenPoint(transform.position);

           if(pos.x < -56) {

               pos.x = 52;
               transform.position = pos;

               }
           else if(pos.x >52 ) {

               pos.x= -56;
               transform.position = pos;
               
               }
          else if(pos.y > 35) {
               pos.y= -30;
               transform.position = pos;
              }
          else if(pos.y <-30) {
               pos.y= 35;
               transform.position = pos;
              }

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg +90f;
        rb.rotation = angle ;
        }
    }
 
    void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject,3f);  
            dead = true;
            Score.score = 0;
            anim.SetBool("Dead",true);
            RestartButton.SetActive(true);
            //Application.LoadLevel(Application.loadedLevel);
        }
    }
}
