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
    public GameObject NextBtn;
    public float Timer;
    public static int SheepN=10;
    public static int NbeSheepPassed = 0;
    public AudioMixer myAM;
    public AudioSource LoseAS;
    public AudioSource BckgAS;
    public AudioSource bleatAS;
    public GameObject Barkbtn;
    public GameObject pausebtn;
    public GameObject pausemenu;
    private float actualLowpass=0;
	// Use this for initialization
	void Start () {
        Debug.Log("volume "+bleatAS.volume);
        if(PlayerPrefs.GetInt("soundIsOn")==0)
        {
            bleatAS.volume = 0;
        }
        if (PlayerPrefs.GetInt("musicIsOn") == 0)
        {
            BckgAS.volume = 0;
        }
        BckgAS.Play();
        LoseAS.Stop();
        StartPanel.SetActive(true);
        RetryBtn.SetActive(false);
        Time.timeScale = 0;
        myAM.SetFloat("Lowpass", 6835f);
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
            myAM.SetFloat("Lowpass", 6835f);
            Barkbtn.SetActive(false);
            Time.timeScale = 0;
        }
        if (NbeSheepPassed== 10)
        {
            FinalMessage.gameObject.SetActive(true);
            BckgAS.Stop();
            NextBtn.SetActive(true);
            
            myAM.SetFloat("Lowpass", 6835f);
            Time.timeScale = 0;
            Barkbtn.SetActive(false);
            FinalMessage.SetText("Good Job !");
            NbeSheepPassed = 0;
            if (PlayerPrefs.HasKey("level2isOn"))
                PlayerPrefs.SetInt("level2isOn", 1);
        }
        if (Timer < 0)
        {
            FinalMessage.gameObject.SetActive(true);
            BckgAS.Stop();
            RetryBtn.SetActive(true);
            myAM.SetFloat("Lowpass", 6835f);
            Time.timeScale = 0;
            Barkbtn.SetActive(false);
            FinalMessage.SetText("Good Job !");
            NbeSheepPassed = 0;

        }
    }
   public void StartGame()
    {
        StartPanel.SetActive(false);
        TimerText.gameObject.SetActive(true);
        myAM.SetFloat("Lowpass", 22000f);
        Barkbtn.SetActive(true);
        pausebtn.SetActive(true);
        Time.timeScale = 1;

    }
public void Retry()
    {
        
        SceneManager.LoadScene("Game");
    }
    public void RetryFlev()
    {

        SceneManager.LoadScene("Game 2");
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
        pausebtn.SetActive(false);
        pausemenu.SetActive(true);
    }
    public void continueGame()
    {
        Time.timeScale = 1;
        pausebtn.SetActive(true);
        pausemenu.SetActive(false);
    }
    public void goHome()
    {
        SceneManager.LoadScene("Menu");
    }
}
