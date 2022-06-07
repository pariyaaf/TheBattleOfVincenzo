using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public AudioSource hit, jumpsound , gem , door;
    public GameObject panel;
       public Text scoreText ;
    private int score = 0;

    public float speed = 5; //player speed

    private bool isGrounded = false;//بررسی اینکه به زمین برخورد داره یا نه برای  پرشش
    private Rigidbody2D rb;

    public float jump = 5;// یعنی ۵ تا برو بالا برای پریدن استفاده میکنیم


    private Animator anim;

        //3
     private Vector3 rotation;// برای تغییر حهت شکل کاراکتر
 

 void Start(){
     score = 0;
             scoreText.text ="Score : "+score.ToString();

     panel.SetActive(false);
     rb = GetComponent<Rigidbody2D>();


     anim = GetComponent<Animator>();


    rotation = transform.eulerAngles;

 }
    void Update(){
        scoreText.text ="Score : "+score.ToString();
        float direction = Input.GetAxis("Horizontal");
 
        if(direction !=0){
            anim.SetBool("isRunning", true);

        }
        else
        {
            anim.SetBool("isRunning" , false);
        }



 
        if(direction<0){
            transform.eulerAngles = rotation -new Vector3(0,180,0);
                transform.Translate(Vector2.right * speed * -direction* Time.deltaTime);

        
        }
        if(direction>0){
            transform.eulerAngles = rotation;
                    transform.Translate(Vector2.right * speed * direction* Time.deltaTime);

        }



    if(isGrounded ==false){
       anim.SetBool("isJumping",true);
    }
    if(isGrounded ==true){
        anim.SetBool("isJumping",false);
    }






    
    if((Input.GetKeyDown(KeyCode.Space) && (isGrounded == true)))//اند اند بعدا اضافه شده که نره خیلی بالا
    {  jumpsound.Play();
        rb.AddForce(Vector2.up * jump , ForceMode2D.Impulse);//۵ تا برو بالا
        isGrounded = false;
    }
    }
     private  void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "ground"){
            isGrounded = true;
        } 
     }
     
     private  void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "coin"){
            gem.Play();
            Destroy(other.gameObject);
              score = score + 2;
            scoreText.text = "Score : "+score.ToString();
        }

        if(other.gameObject.tag == "furry"){
            hit.Play();
            anim.SetBool("crush",true);
               scoreText.text = "Score : "+score.ToString();

            Invoke("endcrush",1.4f);
        } 


                if(other.gameObject.tag == "door"){
            door.Play();
            anim.SetBool("crush",true);
            Destroy(gameObject);
            Invoke("endcrush",1.4f);
        } 

     }
     private void endcrush(){
            panel.SetActive(true);
        anim.SetBool("crush",false);
        anim.SetBool("end",true);
                        
     }
    
    


}
