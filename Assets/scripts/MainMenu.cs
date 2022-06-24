using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject MenuPanel;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void btnExit(){
        Application.Quit();
    }

    public void GoToLevel1(){
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("L1");
    }
    public void GoToLevel2(){
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("L2");
    }
    public void GoToLevel3(){
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("L3");
    }
    public void GoToLevel4(){
         FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("L4");
    }
    public void GoToLevel5(){
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("L5");
    }
    // public void GoToLevel6(){
        //FindObjectOfType<AudioManager>().Play("Button");

    //     SceneManager.LoadScene("L6");
    // }

    public void GoToMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void btnMenu(){
        MenuPanel.SetActive(true);
    }
    public void btnOk(){
        MenuPanel.SetActive(false);
    }
}
