using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject pnlCredits;
    public GameObject[] pnlTutorials;

    public float fadeTime;
	
	public void StartSinglePlayer()
    {
        SceneManager.LoadScene(1);
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
