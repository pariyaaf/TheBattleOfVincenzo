using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public int next ;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        Invoke("Nextscene",6f);
    }

    private void Nextscene(){
       
            SceneManager.LoadScene(1);
        }

    
}
