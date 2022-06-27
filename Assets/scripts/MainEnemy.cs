using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainEnemy : MonoBehaviour
{
//buster age

    private int lifecount =0;

    public AnimationCurve curve;

    public float speed = 3f;
    public float velocity;
    public float links;
    private Vector3 rotation;
    [HideInInspector]
    public  Animator animMainEnemy;

    public GameObject deadLight;
    private GameObject tmplight;
    public GameObject vincenzochar;
    public GameObject Losepanel;
    int healthNum = 5;

    public GameObject imgScore0, imgScore1, imgScore2, imgScore3, imgScore4, imgScore5;

    //for  clone vincenzo
   // private Rigidbody2D vinRb;
    //private Vincenzo VinScript;
    //private Collider2D colliders ;


    
        [SerializeField]
        private List<GameObject> vinlist = new List<GameObject>();

     void Start()
    {
        velocity = transform.position.x + velocity;
        links = transform.position.x - links;
        rotation = transform.eulerAngles;
        animMainEnemy = GetComponent<Animator>();

        //for clone vincelzo


        //vinRb = vincenzochar.GetComponent<Rigidbody2D>();
        ///VinScript = vincenzochar.GetComponent<Vincenzo>();
       // colliders = vincenzochar.GetComponent<Collider2D>();
        
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
            DecreasedHealthDueMainEnemy();
                     tmplight =   Instantiate(deadLight, transform.position , Quaternion.identity);
                                             FindObjectOfType<AudioManager>().Play("vincenzoDying");

                        Invoke("Destroylight",1f);

                    Destroy(other.gameObject);

                    if(lifecount<4)
                    {
                        vinlist[lifecount].SetActive(true);

                        lifecount++;

                    }
                    else{
                        Losepanel.SetActive(true);
                        Time.timeScale=0;
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
private void Destroylight(){
    Destroy(tmplight);
}
public void DecreasedHealthDueMainEnemy(){
        healthNum--;
        switch(healthNum){
    case 0:
        setActiveFalse();
        imgScore0.SetActive(true);
        
    break;
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
    break;
}
}
public void setActiveFalse(){
        imgScore0.SetActive(false);
        imgScore1.SetActive(false);
        imgScore2.SetActive(false);
        imgScore3.SetActive(false);
        imgScore4.SetActive(false);
        imgScore5.SetActive(false);
    }
}

