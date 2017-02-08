using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectTap : MonoBehaviour {

    public bool active = true;
    public bool notTouch = true;
    public GameObject outlinedObject;
    GameController gElements;

    void Start()
    {
        gElements = FindObjectOfType<GameController>();
    }

    public void Activate()
    {
        active = false;
        StartCoroutine(Time());
        StartCoroutine(Action());
        outlinedObject.SetActive(true);
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(0.1f);

        gElements.dubbio.fillAmount += 0.01f;

        if (notTouch == true)
            StartCoroutine(Time());
    }

    IEnumerator Action ()
    {
        yield return new WaitForSeconds(2);

        outlinedObject.SetActive(false);
        active = true;
	}


	
	
	void OnMouseDown ()
    {
        notTouch = false;
	}
}
