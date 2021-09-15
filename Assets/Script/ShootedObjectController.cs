using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootedObjectController : MonoBehaviour
{
  
  
    public GameObject tryAgainPanelSame, nextLevelPanel;
    
    private float score;
    public Text scoreText;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Obstacle")
        {
            PlayerManager.isGameStarted = false;
            tryAgainPanelSame.SetActive(true);
            Debug.Log("Number Of Rights: ");
            Time.timeScale = 0;
            
        }
        
        if(other.gameObject.tag == "winTarget")
        {
            StartCoroutine(WaitForEnd());
            Debug.Log("You win!!!");
            score += 100;
            Debug.Log("You made score!!!");
            scoreText.text = "SCORE : " + score;
            

        }
        if(other.gameObject.tag == "beforeWin")
        {
            score += 100;
            scoreText.text = "SCORE : " + score;
        }
        
    }
    
    private IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(1.0f);
        PlayerManager.isGameStarted = false;
        nextLevelPanel.SetActive(true);
    }

    
}
