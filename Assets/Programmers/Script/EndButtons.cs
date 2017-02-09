using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndButtons : MonoBehaviour {

    public string nameRigiocaScene;
    public string nameHomeScene;
    MusicManager mElements;

    void Start()
    {
        mElements = FindObjectOfType<MusicManager>();
    }

    public void Rigioca ()
    {
        mElements.PlayMusic(1);
        SceneManager.LoadScene(nameRigiocaScene);
	}


    public void Home()
    {
        mElements.PlayMusic(0);
        SceneManager.LoadScene(nameHomeScene);
        
    }
}
