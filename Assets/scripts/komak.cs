using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class komak : MonoBehaviour
{   private Animator x ;
    public MainEnemy lastEnemy ;
    public GameObject lastEnemyPos;
    // Start is called before the first frame update
    void Start()
    {
    lastEnemy = GameObject.FindGameObjectWithTag("mainenemy").GetComponent<MainEnemy>();    }
    // Update is called once per frame
    void Update()
    {
        float posx = lastEnemyPos.transform.position.x;
    transform.position = new Vector2(posx , transform.position.y);
    }
               
    
  private  void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Vincenzo"){
            lastEnemy.animMainEnemy.SetBool("MainEnemyhurting",true);
            Invoke("changetoIdle",0.5f);
                    }
  }
                    private void changetoIdle(){
        lastEnemy.animMainEnemy.SetBool("MainEnemyhurting",false);}
  
}

