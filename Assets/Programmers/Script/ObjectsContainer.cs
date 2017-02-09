using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectsContainer : MonoBehaviour {

	public List<ObjectTap> listaOggetti; 

	void Awake ()
    {
        listaOggetti = new List<ObjectTap>();
        GetComponentsInChildren<ObjectTap>(listaOggetti);
	}
	
	
	public void ActiveAnObject (GameObject a)
    {
        ObjectTap obj = listaOggetti[Random.Range(0, listaOggetti.Count)];

        if (obj.active == true)
        {
            obj.Activate();
            obj.ispirazione = a;
        }
            
	}
}
