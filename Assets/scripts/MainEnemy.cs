using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainEnemy : MonoBehaviour
{
//buster age

    private int lifecount =2;

    public AnimationCurve curve;

    public float speed = 3f;
    public float velocity;
    public float links;
    private Vector3 rotation;
    [HideInInspector]
    public  Animator animMainEnemy;

    public GameObject deadLight;
    public GameObject vincenzochar;

     void Start()
    {
        velocity = transform.position.x + velocity;
        links = transform.position.x - links;
        rotation = transform.eulerAngles;
        animMainEnemy = GetComponent<Animator>();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.W)){  
            lifecount ++;


        }        
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x < links) {
            transform.eulerAngles = rotation;
            speed = 0;
            Invoke("RunAgaine",1f);

        }
        if (transform.position.x > velocity) {
                transform.eulerAngles = rotation - new Vector3(0,180,0);
                speed = 0 ;
            Invoke("RunAgaine",1f);

        }
    }
   private  void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Vincenzo"){
                        Instantiate(deadLight, transform.position , Quaternion.identity);
                    Destroy(other.gameObject);

                    if(lifecount>0)
                    {
                        Instantiate(vincenzochar,new Vector3 (5,10,-10) , Quaternion.identity);
                        lifecount--;

                    }
                    else{
                        Invoke("GoMainMenu",3f);
                    }
                                        }
  }

    private void RunAgaine()
    {
        speed = 10;
    }
    private void GoMainMenu()
{
    SceneManager.LoadScene(2);

}



    
}

