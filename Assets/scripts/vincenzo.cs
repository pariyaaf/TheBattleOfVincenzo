using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class vincenzo : MonoBehaviour
{

    //از خودم اینو میزنم برای انیکه متناسسب با اینکه فالس یا ترو هست بیاد جهت حرکت اتیش رو مشخص کنه
    public bool isDrectionRight = true;

    public GameObject fireScript;
    [HideInInspector] 
    public static  bool throwFire = false;
    //sounds


    //panel
    public GameObject panel;

    //score
    public Text scoreText ;
    private int score = 0;

    //player
    public float speed = 5; 
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 rotation;


    //jump
    private bool isGrounded = false;
    public float jump = 5;


  

    void Start(){

        panel.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;

 }

    void Update(){
        float direction = Input.GetAxis("Horizontal");
 
        if(direction !=0){
            anim.SetBool("IsRunning", true);
        }

        else{
            anim.SetBool("IsRunning" , false);
        }

        if(direction<0){
            transform.eulerAngles = rotation -new Vector3(0,180,0);
                transform.Translate(Vector2.right * speed * -direction * Time.deltaTime);
                isDrectionRight = false;
        }

        if(direction>0){
            transform.eulerAngles = rotation;
                    transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
                    isDrectionRight = true;
        }



        if(isGrounded == false) 
          anim.SetBool("IsJumping",true);  
        if(isGrounded == true) 
           anim.SetBool("IsJumping",false);

        
        //if(isGrounded ==true){
       // }

        if((Input.GetKeyDown(KeyCode.Space) && (isGrounded == true))){  
            rb.AddForce(Vector2.up * jump , ForceMode2D.Impulse);
            isGrounded = false;
        }

        if(Input.GetKeyDown(KeyCode.Return)){  
                if(anim.GetBool("IsHurting") == true)
                    anim.SetBool("IsHurting",false);
                anim.SetBool("IsFighting",true);
                Invoke("changeIsFighting",1);
        }

         if(Input.GetKeyDown(KeyCode.Delete)){  
                anim.SetBool("fireAttack",true);
                throwFire = true;
                fireScript.GetComponent<Fire>().fireMove();
                Invoke("changeIsFireAttacking",0.4f);


        }


    }

    private  void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "ground"){
            isGrounded = true;
        } 
    }
        
    private  void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "coin"){
            Destroy(other.gameObject);

        }

        if(other.gameObject.tag == "enemyOne"){
            if(anim.GetBool("IsFighting") == false){
                anim.SetBool("IsHurting",true);
                //score--
            }
            else{
            anim.SetBool("IsHurting",false);
            Destroy(other.gameObject);
            }
       }


        if(other.gameObject.tag == "enemyTwoHead"){
            Destroy(other.gameObject);
        }

            //Invoke("endcrush",1.4f);
         


    }
    
    private void endcrush(){
        panel.SetActive(true);
        anim.SetBool("IsDead",false);
        anim.SetBool("Restart",true);
                            
        }

    private void changeIsFighting(){
        anim.SetBool("IsFighting",false);
    }

     private void changeIsFireAttacking(){
        anim.SetBool("fireAttack",false);
    }

        
    }
