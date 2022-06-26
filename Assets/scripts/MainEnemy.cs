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
                     tmplight =   Instantiate(deadLight, transform.position , Quaternion.identity);
                        Invoke("Destroylight",1f);
                    Destroy(other.gameObject);

                    if(lifecount<3)
                    {
                //  GameObject x = Instantiate(vincenzochar,new Vector3 (5,10,-10) , Quaternion.identity);
                // Vector3 vinClonSlace = x.transform.localScale;
                  //vinClonSlace.y = 0.6f;
                  //vinClonSlace.x = 0.6f;
                  //x.transform.localScale = vinClonSlace;

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



    
}

