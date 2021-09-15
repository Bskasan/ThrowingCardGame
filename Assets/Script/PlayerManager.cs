using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameStarted;
    public  GameObject startPanel;
    
   
    void Start()
    {
        isGameStarted = false;
        Time.timeScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameStarted)
        {
            Destroy(startPanel);    
        }
        
    }
    public void StartGame()
    {
        PlayerManager.isGameStarted = true;
        Time.timeScale = 1;
    }

    public void TryAgainLvl1()
    {
        SceneManager.LoadScene("Level 1");
        isGameStarted = true;
        Debug.Log("Number Of Rights: ");
        
        
    }
    public void TryAgainLvl2()
    {
        SceneManager.LoadScene("Level 2");
        isGameStarted = true;
        Debug.Log("Number Of Rights: ");
        
        
    }
    public void TryAgainLvl3()
    {
        SceneManager.LoadScene("Level 3");
        isGameStarted = true;
        Debug.Log("Number Of Rights: ");
        
        
    }
    public void TryAgainLvl4()
    {
        SceneManager.LoadScene("Level 4");
        isGameStarted = true;
        Debug.Log("Number Of Rights: ");
        
        
    }
    public void TryAgainLvl5()
    {
        SceneManager.LoadScene("Level 5");
        isGameStarted = true;
        Debug.Log("Number Of Rights: ");
        
        
    }
    public void NextLevelLvl2()
    {
        SceneManager.LoadScene("Level 2");
        
    }
    public void NextLevelLvl3()
    {
        SceneManager.LoadScene("Level 3");
        
    }
    public void NextLevelLvl4()
    {
        SceneManager.LoadScene("Level 4");
        
    }
    public void NextLevelLvl5()
    {
        SceneManager.LoadScene("Level 5");
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
