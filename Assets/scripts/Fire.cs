using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject vincenzoObj, fire;
    public Vector3 vincenzoPos;
        private Rigidbody2D rb;
        private bool throwFire = Vincenzo.throwFire;



    public void fireMove(){
        vincenzoPos = vincenzoObj.transform.position;
        transform.position = vincenzoPos;
        fire.SetActive(true);



    }
    void Start()
    {
                rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if(throwFire){
        rb.velocity =  new Vector2(5, 0);

        }
    }
}
