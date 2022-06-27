using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class komak : MonoBehaviour
{   private Animator x ;
    public MainEnemy lastEnemy ;
    public GameObject lastEnemyPos;

    //code for  dead
    private int vinatackCount = 10;
    private Rigidbody2D MainEnemyrb;

    public GameObject enemyHead;
    public Text f ;

    public GameObject winPanel;

            [SerializeField]
        private List<GameObject> EnemyLife = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    Time.timeScale = 1f;    
    lastEnemy = GameObject.FindGameObjectWithTag("MainEnemy").GetComponent<MainEnemy>();   
    MainEnemyrb = lastEnemy.GetComponent<Rigidbody2D>();
     }
    // Update is called once per frame
    void Update()
    {
        f.text = vinatackCount.ToString();
        if(vinatackCount==0)
        {
            

            winPanel.SetActive(true);
            Invoke("changescale",1.1f);

           /// lastEnemy.animMainEnemy.SetBool("MainEnemyDying",true);
            MainEnemyrb.simulated = false;
            f.text = "eele";

        }
        float posx = lastEnemyPos.transform.position.x;
    transform.position = new Vector2(posx , transform.position.y);
    }
               
    
  private  void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Vincenzo"){
            if(lastEnemy.animMainEnemy.GetBool("MainEnemyhurting")!=true)
            {
            lastEnemy.animMainEnemy.SetBool("MainEnemyhurting",true);

            vinatackCount -=1;////////////////////////////////////
            enemylifemethod();
            if(vinatackCount>0){
            FindObjectOfType<AudioManager>().Play("MainEnemyHurting");
            Invoke("changetoIdle",1f);
            }
            else if( vinatackCount==0) {
            lastEnemy.animMainEnemy.SetBool("MainEnemyDying",true);
                        FindObjectOfType<AudioManager>().Play("MainEnemyDead");

            MainEnemyrb.simulated = false;
            enemyHead.SetActive(false);
            }

            }
                    }
  }

  //private void OnCollisionStay2D( collision2D other)
  //{

  //}
    private void changetoIdle(){
        lastEnemy.animMainEnemy.SetBool("MainEnemyhurting",false);}
  

  private void enemylifemethod()
  {
    for(int i = 0 ;i<=5 ; i++){
        EnemyLife[i].SetActive(false);
    }
    if(vinatackCount==0){
        EnemyLife[0].SetActive(true);
    }

    if(vinatackCount==1|| vinatackCount ==2){
        EnemyLife[1].SetActive(true);
    }

    if(vinatackCount==3|| vinatackCount ==4){
        EnemyLife[2].SetActive(true);
    }

    if(vinatackCount==5|| vinatackCount ==6){
        EnemyLife[3].SetActive(true);
    }

    if(vinatackCount==7|| vinatackCount ==8){
        EnemyLife[4].SetActive(true);
    }

    if(vinatackCount==9|| vinatackCount ==10){
        EnemyLife[5].SetActive(true);
    }
  }
  private void changescale()

  {            Time.timeScale=0f;
}
}

