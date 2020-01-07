using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
	
	
public class GamePlayManager : MonoBehaviour {
	
	public static GamePlayManager instance; 
	
	[SerializeField]
	public Text countdownText;
	
	public int countdownTimer = 60;
	
	[SerializeField]
	private Text scoreText;
	
	private int scoreCount;
	
	[SerializeField]
	private Image scoreFillUI;
	
	
	void Awake(){
		if(instance == null)
			instance = this;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        DisplayScore(0);
        countdownText.text = countdownTimer.ToString();
        StartCoroutine("Countdown");
    }

    IEnumerator Countdown() {
    	yield return new WaitForSeconds(1f);
    	
    	countdownTimer -= 1;
    	countdownText.text = countdownTimer.ToString();
    	
    	
    	StartCoroutine("Countdown");
    	
    	if (countdownTimer <= 0) {
    		StopCoroutine("Countdown");	
    		
    		//GetComponent(Text).color = Color.yellow;
    		StartCoroutine(RestartGame());
    	}
    } //countdown
    
    public void DisplayScore(int scoreValue) {
    	if(scoreText == null)
    		return;
    	scoreCount += scoreValue;
    	scoreText.text = "$" + scoreCount;
    	scoreFillUI.fillAmount = (float)scoreCount / 100f;
    	
    	if (scoreCount >= 100) {
    		StopCoroutine("Countdown");
    		StartCoroutine(RestartGame());
    	
    	}	
    	
    }
    
    IEnumerator RestartGame() {
    	yield return new WaitForSeconds(4f);
    	
    	UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    	
    }
   
   
 
} //class
