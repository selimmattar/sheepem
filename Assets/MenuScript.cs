using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour {
    public Button level2btn;
    public Sprite lockedbtn;
    public Sprite unlockedbtn;
    public GameObject menuPanel;
    public GameObject levelPanel;
    public GameObject settingsPanel;
    public Button musicbtn;
    public Button soundbtn;
    public Sprite soundOn;
    public Sprite soundOff;
    public Sprite musicOn;
    public Sprite musicOff;
    // Use this for initialization

    void Start () {
        Screen.orientation = ScreenOrientation.Landscape;
        if (!PlayerPrefs.HasKey("musicIsOn"))
            PlayerPrefs.SetInt("musicIsOn", 1);
        if (!PlayerPrefs.HasKey("soundIsOn"))
            PlayerPrefs.SetInt("soundIsOn", 1);
        level2btn.GetComponent<Image>().sprite = lockedbtn;
        if (PlayerPrefs.HasKey("level2isOn"))
        {
           if(PlayerPrefs.GetInt("highestScore") == 1)
            {
                level2btn.GetComponent<Image>().sprite = unlockedbtn;
                level2btn.onClick.AddListener(play2);
            };
        }
        else PlayerPrefs.SetInt("level2isOn", 0);
        if (PlayerPrefs.GetInt("soundIsOn") == 1)
            soundbtn.GetComponent<Image>().sprite = soundOn;
        else soundbtn.GetComponent<Image>().sprite = soundOff;
        if (PlayerPrefs.GetInt("musicIsOn") == 1)
            musicbtn.GetComponent<Image>().sprite = musicOn;
        else musicbtn.GetComponent<Image>().sprite = musicOff;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void play2()
    {
        SceneManager.LoadScene("Game");
    }
    public void soundSwitch()
    {
        
        if (PlayerPrefs.GetInt("soundIsOn") == 1)
        {
            PlayerPrefs.SetInt("soundIsOn", 0);
            soundbtn.GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            PlayerPrefs.SetInt("soundIsOn", 1);
            soundbtn.GetComponent<Image>().sprite = soundOn;
        }
    }
    public void musicSwitch()
    {
        
        if (PlayerPrefs.GetInt("musicIsOn") == 1)
        {
            musicbtn.GetComponent<Image>().sprite = musicOff;
            PlayerPrefs.SetInt("musicIsOn", 0);
        }
        else
        {
            musicbtn.GetComponent<Image>().sprite = musicOn;
            PlayerPrefs.SetInt("musicIsOn", 1);
        }
    }
    public void gotoLevelSelector()
    {
        menuPanel.SetActive(false);
        levelPanel.SetActive(true);
    }
    public void gotoSettings()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void gotomenufromsetting()
    {
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);

    }
    public void play()
    {
        SceneManager.LoadScene("Game 2");
    }
}
