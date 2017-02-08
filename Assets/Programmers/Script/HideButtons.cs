using UnityEngine;
using System.Collections;

public class HideButtons : MonoBehaviour {

    string name;
    public GameObject buttons1;
    public GameObject buttons2;
    public GameObject buttons3;


    void Start()
    {
        name = this.gameObject.name;
    }

    public void State1()
    {

        buttons1.SetActive(true);
        buttons2.SetActive(false);
        buttons3.SetActive(false);
                  
    }

    public void State2()
    {
        buttons1.SetActive(false);
        buttons2.SetActive(true);
        buttons3.SetActive(false);
    }

    public void State3()
    {
        buttons1.SetActive(false);
        buttons2.SetActive(false);
        buttons3.SetActive(true);
    }
}
    
