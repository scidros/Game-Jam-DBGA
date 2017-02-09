﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject pnlCredits;
    public GameObject[] pnlTutorials;
    public SoundManager soundManager;
    public MusicManager musicManager;

    public float fadeTime;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        musicManager = FindObjectOfType<MusicManager>();
    }
	
	public void StartSinglePlayer()
    {
        musicManager.PlayMusic(1);
        SceneManager.LoadScene("Game");
    }

    public void Credits()
    {
        pnlCredits.SetActive(true);
        pnlCredits.GetComponent<Popup>().TogglePopup();
    }

    public void Tutorial()
    {
        pnlTutorials[0].GetComponent<Popup>().TogglePopup();
    }
}
