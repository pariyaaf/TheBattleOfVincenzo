using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using System.Collections;


public class Dragon : MonoBehaviour
{

    
    public float speed = 3f;
    public float velocity;
    public float links;
    private Vector3 rotation;
    private Animator anim;

    void Start()
    {
        velocity = transform.position.x + velocity;
        links = transform.position.x - links;
        rotation = transform.eulerAngles;
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        //22om 
        
          //  Physics2D.IgnoreCollision(GameObject.FindGameObjectsWithTag("enemyOne").GetComponent<Collider>(), GetComponent<Collider>());

        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x < links) {
            transform.eulerAngles = rotation;
        }
        if (transform.position.x > velocity) {
                transform.eulerAngles = rotation - new Vector3(0,180,0);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Vincenzo") {
            FindObjectOfType<AudioManager>().Play("DragonDead");

            anim.SetBool("die" , true);
            Invoke("DragonDestroy", 0.7f);
            
            }
        
    }
    void DragonDestroy(){
            Destroy(gameObject);
        }
}
