using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    public GameObject buttons;

	void OnMouseDown () {

        buttons.SetActive(true);	
	}

    public void Deactive()
    {
        buttons.SetActive(false);
    }
	
	
	void Update () {
	
	}
}
