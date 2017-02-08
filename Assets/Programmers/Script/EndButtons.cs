using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndButtons : MonoBehaviour {

    public string nameRigiocaScene;
    public string nameHomeScene;

    public void Rigioca ()
    {
        SceneManager.LoadScene(nameRigiocaScene);
	}


    public void Home()
    {
        SceneManager.LoadScene(nameHomeScene);
    }
}
