using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour {
    public GameObject StartPanel;
    public GameObject Joystick;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI FinalMessage;
    public GameObject RetryBtn;
    public float Timer;
    public static int SheepN=10;
	// Use this for initialization
	void Start () {

        Joystick.SetActive(false);
        StartPanel.SetActive(true);
        RetryBtn.SetActive(false);
        Time.timeScale = 0;
  
       
        TimerText.gameObject.SetActive(false);
        FinalMessage.gameObject.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update () {
        Timer -= Time.deltaTime;
        TimerText.SetText("" + Mathf.RoundToInt(Timer));
        if (SheepN < 10)
        {
            FinalMessage.gameObject.SetActive(true);
            RetryBtn.SetActive(true);
            FinalMessage.SetText("You Lose !");
            SheepN = 10;
            Time.timeScale = 0;
        }
        if (Timer <= 0)
        {
            FinalMessage.gameObject.SetActive(true);
            
            RetryBtn.SetActive(true);
            Time.timeScale = 0;
            FinalMessage.SetText("Good Job !");
        }
    }
   public void StartGame()
    {
        StartPanel.SetActive(false);
        Joystick.SetActive(true);
        TimerText.gameObject.SetActive(true);
        Time.timeScale = 1;

    }
public void Retry()
    {
        
        SceneManager.LoadScene("Game");
    }
}
