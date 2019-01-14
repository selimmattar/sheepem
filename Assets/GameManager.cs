using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
public class GameManager : MonoBehaviour {

    public GameObject StartPanel;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI FinalMessage;
    public GameObject RetryBtn;
    public float Timer;
    public static int SheepN=10;
    public AudioMixer myAM;
    public AudioSource LoseAS;
    public AudioSource BckgAS;
    public GameObject Barkbtn;
    private float actualLowpass=0;
	// Use this for initialization
	void Start () {
        BckgAS.Play();
        LoseAS.Stop();
        StartPanel.SetActive(true);
        RetryBtn.SetActive(false);
        Time.timeScale = 0;
        myAM.SetFloat("Lowpass", 350f);
        //TimerText.gameObject.SetActive(false);
        FinalMessage.gameObject.SetActive(false);
        Barkbtn.SetActive(false);

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
            BckgAS.Stop();
            LoseAS.Play();
            myAM.SetFloat("Lowpass", 350f);
            Barkbtn.SetActive(false);
            Time.timeScale = 0;
        }
        if (Timer <= 0)
        {
            FinalMessage.gameObject.SetActive(true);
            BckgAS.Stop();
            RetryBtn.SetActive(true);
            myAM.SetFloat("Lowpass", 350f);
            Time.timeScale = 0;
            Barkbtn.SetActive(false);
            FinalMessage.SetText("Good Job !");
        }
    }
   public void StartGame()
    {
        StartPanel.SetActive(false);
        TimerText.gameObject.SetActive(true);
        myAM.SetFloat("Lowpass", 22000f);
        Barkbtn.SetActive(true);
        Time.timeScale = 1;

    }
public void Retry()
    {
        
        SceneManager.LoadScene("Game");
    }
}
