using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject pnlCredits;
    public GameObject[] pnlTutorials;
    public MusicManager musicManager;

    public float fadeTime;

    void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
    }
	
	public void StartSinglePlayer()
    {
        musicManager.PlayMusic(1);
        SceneManager.LoadScene("Game");
    }

    public void Credits()
    {
        pnlCredits.GetComponent<Popup>().TogglePopup();
    }

    public void Tutorial()
    {
        pnlTutorials[0].GetComponent<Popup>().TogglePopup();
    }
}
