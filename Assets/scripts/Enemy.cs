using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float velocity;
    public float links;
    private Vector3 rotation;
    private Animator anim;
    public GameObject player;
    private Vector2 playerPos;

    void Start()
    {
        rotation = transform.eulerAngles;
        anim = GetComponent<Animator>();
        
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

     private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "player") {
            anim.SetBool("attack" , true);
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "player") {
            anim.SetBool("attack" , false);
        }
    }
}
