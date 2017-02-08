using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectTap : MonoBehaviour {

    public bool active = true;
    public bool notTouch = true;
    GameController gElements;
    Image sr;
    Color a;

    void Start()
    {
        gElements = FindObjectOfType<GameController>();
        sr = this.GetComponent<Image>();
        a = sr.color;
    }

    public void Activate()
    {
        active = false;
        StartCoroutine(Time());
        StartCoroutine(Action());
        a.a -= 0.50f;
        sr.color = a;
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

        a.a = 1f;
        sr.color = a;
        active = true;
	}


	
	
	void OnMouseDown ()
    {
        notTouch = false;
	}
}
