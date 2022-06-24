using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEnemy : MonoBehaviour
{
    private float jump ;
    private Rigidbody2D rb;
    private  bool ground = true;
    void Start()
    {
          rb = GetComponent<Rigidbody2D>();
    }

      void Update()
    {
        if (ground == true)
            {
            ground = false;
            rb.AddForce(Vector2.up * Random.Range(5f,12f) , ForceMode2D.Impulse);
            Invoke("jumping",5);
        }

    }
    private void jumping(){
          ground = true; 
    }
    
}
