using UnityEngine;
using System.Collections;


public class Interactable : MonoBehaviour {

    public Movable[] oggettiAttivare;
    public Movable[] oggettiDisattivare;
    

    public void OnMouseDown ()
    {

        Debug.Log("prova");

        if(oggettiAttivare != null)
        foreach (var oggetto in oggettiAttivare)
            oggetto.activate = true;

        if (oggettiDisattivare != null)
            foreach (var oggetto in oggettiDisattivare)
            oggetto.activate = true;
	}
	
	
	void Update ()
    {
	
	}
}
