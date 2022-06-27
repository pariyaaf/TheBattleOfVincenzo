using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwordMove : MonoBehaviour
{
private float rotationSpeed=30;
public GameObject privotObject;

    
    

    void Update()
    {
       transform.RotateAround(privotObject.transform.position, new Vector3 (1, 1, 0) ,rotationSpeed* Time.deltaTime);

    }
}
