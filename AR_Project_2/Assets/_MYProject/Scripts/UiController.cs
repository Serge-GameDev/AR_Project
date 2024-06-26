using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;


public class UiController : MonoBehaviour

{
    [SerializeField] private GameObject popUpMenu;
    
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenEndScreen()
    {
        Time.timeScale = 0;
        popUpMenu.SetActive(true);

    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
       
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
