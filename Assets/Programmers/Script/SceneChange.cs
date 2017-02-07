using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public string nameScene;


    void OnMouseDown()
    {
        SceneManager.LoadScene(nameScene);
    }


}
