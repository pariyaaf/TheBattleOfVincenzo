using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vincenzo : MonoBehaviour
{

//public GameObject swordCollider;

    //pariya22om
    //public GameObject fameleEnemy;
    public GameObject killlight;
    private GameObject[] enemies;
    GameObject[] dragons;
    GameObject[] blackenemies;

    //از خودم اینو میزنم برای انیکه متناسسب با اینکه فالس یا ترو هست بیاد جهت حرکت اتیش رو مشخص کنه
    public static bool isDrectionRight = false;

    public GameObject fireScript;
    [HideInInspector]
    public static bool throwFire = false;
    //pariya
    public GameObject tunder;
    private bool disable = false;


    //sounds


    //Winpanel
    public GameObject Winpanel;
    public GameObject Losepanel;

    //score
    public Text scoreText;
    public GameObject killDragonLight;
    public GameObject GetHeathLight;

    //player
    public float speed = 5;
    private Rigidbody2D rb;

    //public GameObject swordCollider;

   // [HideInInspector]
    private Animator anim;
    private Vector3 rotation;


    //jump
    private bool isGrounded = false;
    public float jump = 5;


    //maryam - کم شدن جون کاراکتر با شمشیر خوردن و برخورد به دراگون
    public int AttackNumber = 0;
    public int dragonDie = 0;
    public int helthNum = 5;
    bool invincible = false;
    public Text dragonScore, swordScore;
    public int healthNum = 5;
    float iTime = 1.5f;
    float iCounter = 0;
    private int DragonScore, SwordScore;


    //health
    public GameObject imgScore0, imgScore1, imgScore2, imgScore3, imgScore4, imgScore5;



    void Start()
    {

        DragonScore = PlayerPrefs.HasKey("DraginScore") ? PlayerPrefs.GetInt("DraginScore") : 0;
        SwordScore = PlayerPrefs.HasKey("SwordScore") ? PlayerPrefs.GetInt("SwordScore") : 0;
        dragonScore.text = DragonScore.ToString();
        swordScore.text = SwordScore.ToString();

        //pariya22om
        enemies = GameObject.FindGameObjectsWithTag("enemyOne");
        dragons = GameObject.FindGameObjectsWithTag("DragonBody");
        blackenemies = GameObject.FindGameObjectsWithTag("BlackEnemy");

        Winpanel.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
        Time.timeScale = 1f;

    }
    void Update()
    {
        IncreasedHealthDragon();

        if (anim.GetBool("IsHurting"))
        {
            if(!invincible){
                    AttackNumber++;
                if (AttackNumber >= 5)
                    DecreasedHealthDueEnemy1();

            invincible = true;
            }
        }

        if (invincible)
        {
            iCounter += Time.deltaTime;
            if (iCounter >= iTime)
            {
                iCounter = 0;
                invincible = false;
            }
        }

        float direction = Input.GetAxis("Horizontal");

        if (direction != 0)
        {
            anim.SetBool("IsRunning", true);
        }

        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (direction < 0)
        {
            transform.eulerAngles = rotation - new Vector3(0, 180, 0);
            transform.Translate(Vector2.right * speed * -direction * Time.deltaTime);
            isDrectionRight = false;
        }

        if (direction > 0)
        {
            transform.eulerAngles = rotation;
            transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
            isDrectionRight = true;
        }

        if (isGrounded == false)
            anim.SetBool("IsJumping", true);
        if (isGrounded == true)
            anim.SetBool("IsJumping", false);

        if ((Input.GetKeyDown(KeyCode.Space) && (isGrounded == true)))
        {
            FindObjectOfType<AudioManager>().Play("vincenzojumping");

            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetBool("IsHurting", false);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (anim.GetBool("IsHurting") == true)
                anim.SetBool("IsHurting", false);

            FindObjectOfType<AudioManager>().Play("Sword");

            anim.SetBool("IsFighting", true);
           // swordCollider.SetActive(true);
            Invoke("changeIsFighting", 1f);
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            anim.SetBool("fireAttack", true);
            throwFire = true;
            fireScript.GetComponent<Fire>().fireMove();
            Invoke("changeFireAttacking", 0.4f);
        }

        if (Input.GetKeyDown(KeyCode.T) && disable == false)
        {            Invoke("endTunder", 1f);


            FindObjectOfType<AudioManager>().Play("Thunder");

            foreach (GameObject enemy in enemies)
            {
                anim.SetBool("UseTunder", true);
                tunder.SetActive(true);
                if (enemy.GetComponent<Renderer>().isVisible)//فک کنم اگه دیگه نداشته باشیم دشمن توی بازی عمل نمیکنه
                {
                    Vector3 enemypos = enemy.transform.position;
                    if (enemypos.x < transform.position.x + 25 && enemypos.x > transform.position.x - 25)
                        GameObject.Destroy(enemy);
                }
            }
            foreach (GameObject enemy in blackenemies)
            {
                anim.SetBool("UseTunder", true);
                tunder.SetActive(true);
                if (enemy.GetComponent<Renderer>().isVisible)//فک کنم اگه دیگه نداشته باشیم دشمن توی بازی عمل نمیکنه
                {
                    Vector3 enemypos = enemy.transform.position;
                    if (enemypos.x < transform.position.x + 25 && enemypos.x > transform.position.x - 25)
                        GameObject.Destroy(enemy);
                }
            }
            foreach (GameObject enemy in dragons)
            {
                anim.SetBool("UseTunder", true);
                tunder.SetActive(true);
                if (enemy.GetComponent<Renderer>().isVisible)//فک کنم اگه دیگه نداشته باشیم دشمن توی بازی عمل نمیکنه
                {
                    Vector3 enemypos = enemy.transform.position;
                    if (enemypos.x < transform.position.x + 25 && enemypos.x > transform.position.x - 25)
                        GameObject.Destroy(enemy);
                }
            }

            disable = true;
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "MainEnemyBody")
        {
            anim.SetBool("IsHurting", true);

        }
        if (collision.gameObject.tag == "WinFlag")
        {
            Winpanel.SetActive(true);
            Time.timeScale = 0;
        } 
        


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EndLevel")
        {
            SceneManager.LoadScene("L6");
        }
        if (other.gameObject.tag == "enemyOne")
        {
            if (anim.GetBool("IsFighting") == false)
            {
                FindObjectOfType<AudioManager>().Play("vincenzoHurting");
                anim.SetBool("IsHurting", true);
            }

             if (anim.GetBool("IsFighting") == true)
            {
                FindObjectOfType<AudioManager>().Play("FenemyDead");
                anim.SetBool("IsHurting", false);
                
                Destroy(other.gameObject);
                            Instantiate(killlight, other.gameObject.transform.position , Quaternion.identity);


                //maryam22om
                //fameleEnemy.GetComponent<FEnemy>().DieEnemy();
            }
        }

        if (other.gameObject.tag == "DragonBody")
        {
            DragonScore++;
            PlayerPrefs.SetInt("DraginScore", DragonScore);
            dragonScore.text = DragonScore.ToString();
            FindObjectOfType<AudioManager>().Play("DragonDead");
            Instantiate(killDragonLight, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Sword")
        {
            SwordScore++;
            PlayerPrefs.SetInt("SwordScore", SwordScore);
            swordScore.text = SwordScore.ToString();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BlackEnemy")
        {
            FindObjectOfType<AudioManager>().Play("vincenzoDying");

            anim.SetBool("IsDead", true);
            foreach (GameObject enemy in enemies)
            {
                GameObject.Destroy(enemy);
            }
            foreach (GameObject dragon in dragons)
            {
                GameObject.Destroy(dragon);
            }
            Invoke("LosePanelSetActive", 2.3f);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemyOne")
        {
            anim.SetBool("IsHurting", false);
        }
    }
    private void endcrush()
    {
        Winpanel.SetActive(true);
        anim.SetBool("IsDead", false);
        anim.SetBool("Restart", true);

    }
    private void changeIsFighting()
    {
        anim.SetBool("IsFighting", false);
         // swordCollider.SetActive(false);
    }
    private void changeFireAttacking()
    {
        anim.SetBool("fireAttack", false);
    }
    private void endTunder()
    {
        anim.SetBool("UseTunder", false);
        tunder.SetActive(false);
    }
    private void LosePanelSetActive()
    {
        imgScore0.SetActive(true);
        Losepanel.SetActive(true);
        Time.timeScale = 0f;

    }
    void resetInvulnerability()
    {
        invincible = false;
    }
    public void IncreasedHealthDragon()
    {               

       if (DragonScore>= 5)
        { 

        if (healthNum == 4)
            {
                PlayerPrefs.SetInt("DragonScore",(DragonScore-5) );
                DragonScore -=5;
                dragonScore.text = DragonScore.ToString();
                Instantiate(GetHeathLight, transform.position, Quaternion.identity);
                healthNum+=1;
                switchHealth(healthNum);
            }
        if (healthNum == 3)
            {
                PlayerPrefs.SetInt("DragonScore",(DragonScore-5) );
                DragonScore -=5;
                dragonScore.text = DragonScore.ToString();
                Instantiate(GetHeathLight, transform.position, Quaternion.identity);
                healthNum+=1;
                switchHealth(healthNum);
            }
        if (healthNum == 2)
            {
                PlayerPrefs.SetInt("DragonScore",(DragonScore-5) );
                DragonScore -=5;
                dragonScore.text = DragonScore.ToString();
                Instantiate(GetHeathLight, transform.position, Quaternion.identity);
                healthNum+=1;
                switchHealth(healthNum);
    }
    if (healthNum == 2)
            {
                PlayerPrefs.SetInt("DragonScore",(DragonScore-5) );
                DragonScore -=5;
                dragonScore.text = DragonScore.ToString();
                Instantiate(GetHeathLight, transform.position, Quaternion.identity);
                healthNum+=1;
                switchHealth(healthNum);
    }
        }
    }
        public void setActiveFalse()
    {
        imgScore0.SetActive(false);
        imgScore1.SetActive(false);
        imgScore2.SetActive(false);
        imgScore3.SetActive(false);
        imgScore4.SetActive(false);
        imgScore5.SetActive(false);
    }
    public void DecreasedHealthDueEnemy1()
    {
        healthNum--;
        AttackNumber = 0;
        switchHealth(healthNum);
    }
    public void switchHealth(int h){
        switch (h)
                {
                    case 1:
                        setActiveFalse();
                        imgScore1.SetActive(true);
                        break;
                    case 2:
                        setActiveFalse();
                        imgScore2.SetActive(true);
                        break;
                    case 3:
                        setActiveFalse();
                        imgScore3.SetActive(true);
                        break;
                    case 4:
                        setActiveFalse();
                        imgScore4.SetActive(true);
                        break;
                    case 5:
                        setActiveFalse();
                        imgScore5.SetActive(true);
                        break;
                    default:
                        setActiveFalse();
                        imgScore0.SetActive(true);
                        break;
                }
    }
}