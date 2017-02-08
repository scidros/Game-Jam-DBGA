using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public string nameScene;


    public void OnMouseDown()
    {
        SceneManager.LoadScene(nameScene);
    }


}
