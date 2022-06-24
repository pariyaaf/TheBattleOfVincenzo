using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Vincenzo : MonoBehaviour
{


//pariya22om
public GameObject fameleEnemy;

    private GameObject[] enemies;
    GameObject[] dragons;
    GameObject[] blackenemies;


    //از خودم اینو میزنم برای انیکه متناسسب با اینکه فالس یا ترو هست بیاد جهت حرکت اتیش رو مشخص کنه
        public static bool isDrectionRight = false;



    public GameObject fireScript;
    [HideInInspector] 
    public static  bool throwFire = false;
    //pariya
    public GameObject tunder;
    private bool disable = false;
    

    //sounds


    //panel
    public GameObject panel;

    //score
    public Text scoreText ;
    private int score = 0;
    public GameObject killDragonLight;

    //player
    public float speed = 5; 
    private Rigidbody2D rb;

   //public GameObject swordCollider;

    [HideInInspector] 
    public Animator anim;
    private Vector3 rotation;


    //jump
    private bool isGrounded = false;
    public float jump = 5;


    //maryam - کم شدن جون کاراکتر با شمشیر خوردن و برخورد به دراگون
    public int AttackNumber = 0;
    public int HurtNumber = 0;
    public int helthNum = 5;
    public Text helthText, test;
    bool i = false;


  

    void Start(){

        //pariya22om
        enemies = GameObject.FindGameObjectsWithTag("enemyOne");
        dragons = GameObject.FindGameObjectsWithTag("DragonBody");
        blackenemies = GameObject.FindGameObjectsWithTag("BlackEnemy");

        panel.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;

 }

    void Update(){
        
        // کد کم شدن جون کاراکتر با ضربه شمشیر انمی زن
        // if(i == true){
        //     Invoke("increasedAttackNumber",5f);
        //     if(AttackNumber>=5)
        //         DecreasedHealthDueEnemy1();
                        
        //         }

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

        if((Input.GetKeyDown(KeyCode.Space) && (isGrounded == true))){  
            FindObjectOfType<AudioManager>().Play("vincenzojumping");

            rb.AddForce(Vector2.up * jump , ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetBool("IsHurting",false);
        }

        if(Input.GetKeyDown(KeyCode.Return)){  
                if(anim.GetBool("IsHurting") == true)
                    anim.SetBool("IsHurting",false);

            FindObjectOfType<AudioManager>().Play("Sword");

                anim.SetBool("IsFighting",true);
                //swordCollider.SetActive(true);
                Invoke("changeIsFighting",1f);
        }

         if(Input.GetKeyDown(KeyCode.Delete)){  
                anim.SetBool("fireAttack",true);
                throwFire = true;
                fireScript.GetComponent<Fire>().fireMove();
                Invoke("changeFireAttacking",0.4f);
         }

        if(Input.GetKeyDown(KeyCode.T) && disable == false)
        {

            FindObjectOfType<AudioManager>().Play("Thunder");

            foreach(GameObject enemy in enemies)
            {
                anim.SetBool("UseTunder",true);
                tunder.SetActive(true);
            if (enemy.GetComponent<Renderer>().isVisible)//فک کنم اگه دیگه نداشته باشیم دشمن توی بازی عمل نمیکنه
                {
                Vector3 enemypos = enemy.transform.position;
                if(enemypos.x<transform.position.x+25 && enemypos.x> transform.position.x-25 )
                    GameObject.Destroy(enemy);
                }
            }
            foreach(GameObject enemy in blackenemies)
            {
                anim.SetBool("UseTunder",true);
                tunder.SetActive(true);
            if (enemy.GetComponent<Renderer>().isVisible)//فک کنم اگه دیگه نداشته باشیم دشمن توی بازی عمل نمیکنه
                {
                Vector3 enemypos = enemy.transform.position;
                if(enemypos.x<transform.position.x+25 && enemypos.x> transform.position.x-25 )
                    GameObject.Destroy(enemy);
                }
            }
            foreach(GameObject enemy in dragons)
            {
                anim.SetBool("UseTunder",true);
                tunder.SetActive(true);
            if (enemy.GetComponent<Renderer>().isVisible)//فک کنم اگه دیگه نداشته باشیم دشمن توی بازی عمل نمیکنه
                {
                Vector3 enemypos = enemy.transform.position;
                if(enemypos.x<transform.position.x+25 && enemypos.x> transform.position.x-25 )
                    GameObject.Destroy(enemy);
                }
                Invoke("endTunder",1f);
            }
            disable = true;
        }

    }

    private  void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "ground"){
            isGrounded = true;
        }
         if(collision.gameObject.tag == "MainEnemyBody"){
                anim.SetBool("IsHurting",true);
            }
        if(collision.gameObject.tag == "WinFlag"){
          //  FindObjectOfType<AudioManager>().Play("vincenzoHurting");
            Invoke("goToMainMenu",1f);
            }

       
    }

    private  void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "coin"){
            Destroy(other.gameObject);
        }
        


        if(other.gameObject.tag == "enemyOne"){
            if(anim.GetBool("IsFighting") == false){
                FindObjectOfType<AudioManager>().Play("vincenzoHurting");

                anim.SetBool("IsHurting",true);

                i = true;

                // while(anim.GetBool("IsFighting")){
                //     Invoke("increasedAttackNumber",5f);
                //     if(AttackNumber>=5)
                //         DecreasedHealthDueEnemy1();
                // }
            }
                    
            

        
            else if(anim.GetBool("IsFighting") == true){
                FindObjectOfType<AudioManager>().Play("FenemyDead");

            anim.SetBool("IsHurting",false);
            i = false;

            //maryam22om
            fameleEnemy.GetComponent<FEnemy>().DieEnemy();
            }
       

       //22om
        if(other.gameObject.tag == "DragonBody"){
            anim.SetBool("IsHurting",true);
            HurtNumber++;
            if(HurtNumber==3)
                DecreasedHealthDueDragon();
            
        }}



         if(other.gameObject.tag == "BlackEnemy"){
            FindObjectOfType<AudioManager>().Play("vincenzoDying");

            anim.SetBool("IsDead",true);
              foreach(GameObject enemy in enemies){
                    GameObject.Destroy(enemy);
            }
            foreach(GameObject dragon in dragons){
                    GameObject.Destroy(dragon);
            }

            Invoke("ReloadLevel",2f);

        }


    }

    private  void OnCollisionExit2D(Collision2D collision){
            if(collision.gameObject.tag == "enemyOne"){
                anim.SetBool("IsHurting", false);
            }
            //ariya 2oo,m
            if(collision.gameObject.tag == "DragonBody"){
                anim.SetBool("IsHurting", false);
            }
         //    if(collision.gameObject.tag == "MainEnemyBody"){
          //      anim.SetBool("IsHurting",false);
          //  }
        }

    private void endcrush(){
        panel.SetActive(true);
        anim.SetBool("IsDead",false);
        anim.SetBool("Restart",true);
                            
        }

    private void changeIsFighting(){
        anim.SetBool("IsFighting",false);
      //  swordCollider.SetActive(false);
    }

     private void changeFireAttacking(){
        anim.SetBool("fireAttack",false);
    }

    private void endTunder(){
        anim.SetBool("UseTunder",false);
        tunder.SetActive(false);
    }

    private void goToMainMenu()
    {
                    SceneManager.LoadScene("MainMenu");

    }
    

    private void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    //maryam
    public void increasedAttackNumber(){
        AttackNumber++;
    }
    public void DecreasedHealthDueEnemy1(){
        helthNum--;
        AttackNumber = 0;
        switch(helthNum)
{
    case 0:
        helthText.text = "0";
        anim.SetBool("isDead",false);
        Destroy(gameObject);
    break;
    case 1:
        helthText.text = "1";
    break;
    case 2:
        helthText.text = "2";
    break;
    case 3:
        helthText.text = "3";
    break;
    case 4:
        helthText.text = "4";
    break;
    case 5:
        helthText.text = "5";
    break;
    default:
        helthText.text = "warning!";
    break;
}
    }
    public void DecreasedHealthDueDragon(){
        helthNum--;
        switch(helthNum)
{
    case 0:
        helthText.text = "0";
    break;
    case 1:
        helthText.text = "1";
    break;
    case 2:
        helthText.text = "2";
    break;
    case 3:
        helthText.text = "3";
    break;
    case 4:
        helthText.text = "4";
    break;
    case 5:
        helthText.text = "5";
    break;
    default:
        helthText.text = "warning!";
    break;
}
    }
    }
