using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEnemy : MonoBehaviour
{   

    public float speed = 3f;
    public float velocity;
    public float links;
    private Vector3 rotation;
    private Animator animenemy;
    public GameObject player;
    private Vector2 playerPos;

  


    void Start()
    {
        rotation = transform.eulerAngles;
        animenemy = GetComponent<Animator>();

        //pariya
       // vcode = GetComponent<Vincenzo>();


        
    }

    void Update()
    {
        move();
    }

    void move(){
        playerPos = player.transform.position;

        if(transform.position.x > playerPos.x){
            transform.position += new Vector3(-speed*Time.deltaTime, 0);
            transform.eulerAngles = rotation - new Vector3(0,180,0);
        }
        
        if(transform.position.x < playerPos.x){
            transform.position += new Vector3(speed*Time.deltaTime, 0);
            transform.eulerAngles = rotation;
        }
    }
    //pariya
     private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Vincenzo") {
            animenemy.SetBool("ShesAttack" , true);
           // if(vcode.anim.GetBool("IsFighting") == true){
           // if(Vincenzo.isAtack == true){
                //maryam

            //    animenemy.SetBool("ShesDie",true);
             //   Invoke("killEnmey",1f);
     //   }


        }
        else if(collision.gameObject.tag == "Vincenzo"  )
        {
                        animenemy.SetBool("ShesAttack" , false);

        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Vincenzo") {
            animenemy.SetBool("ShesAttack" , false);
        }
    }
                //maryam
    public void DieEnemy(){
            animenemy.SetBool("ShesAttack",false);
            animenemy.SetBool("ShesDie",true);
            Invoke("killEnmey",0.1f);
       }
    

    private void destroyEnmey()
    {
        Destroy(gameObject);
    }
}
