using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using System.Collections;


public class Dragon : MonoBehaviour
{

    
    public float speed = 3f;
    public float velocity;
    public float links;
    private Vector3 rotation;


    void Start()
    {
        velocity = transform.position.x + velocity;
        links = transform.position.x - links;
        rotation = transform.eulerAngles;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x < links) {
            transform.eulerAngles = rotation;
        }
        if (transform.position.x > velocity) {
                transform.eulerAngles = rotation - new Vector3(0,180,0);
        }
    }
   
}
