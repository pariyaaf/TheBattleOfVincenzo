using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
  
    public GameObject vincenzoObj, fire;
    public Vector3 vincenzoPos;
        private Rigidbody2D rb;
        private bool throwFire = Vincenzo.throwFire;
     //   public Text loca;


        //direction 
        private bool directionOfFire = Vincenzo.isDrectionRight;
            private Vector3 rotation;

            //
            public GameObject deadLight;




    public void fireMove(){
        FindObjectOfType<AudioManager>().Play("Fire");

        vincenzoPos = vincenzoObj.transform.position;
        transform.position = vincenzoPos;
     //   loca.text = Vincenzo.isDrectionRight.ToString();
        fire.SetActive(true);
        rb.velocity = new Vector2(0,0);
    }
    void Start()
    {
                rb = GetComponent<Rigidbody2D>();

                        rotation = transform.eulerAngles;


    }

    void Update()
    {
        if (Vincenzo.isDrectionRight == true)
        {
            transform.eulerAngles = rotation;

        rb.velocity +=  new Vector2(0.5f, 0);
        }
                       
        else if (Vincenzo.isDrectionRight == false)

        {

            transform.eulerAngles = rotation -new Vector3(0,180,0);

                rb.velocity -=  new Vector2(0.5f, 0);
        }




    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enemyOne") {
            Destroy(other.gameObject);
            Instantiate(deadLight, transform.position , Quaternion.identity);

                    fire.SetActive(false);


            }
    }
}
