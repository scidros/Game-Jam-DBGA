using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectTap : MonoBehaviour {

    public bool active = true;
    public bool notTouch = true;
    public GameObject outlinedObject;
    GameController gElements;
    SoundManager sElements;
    public GameObject ispirazione;

    void Start()
    {
        gElements = FindObjectOfType<GameController>();
        sElements = FindObjectOfType<SoundManager>();
    }


    public void Activate()
    {
        this.GetComponent<Button>().interactable = true;
        active = false;
        StartCoroutine(Time());
        StartCoroutine(Action());
        outlinedObject.SetActive(true);
        StartCoroutine("FlashObj");
        notTouch = true;
    }

    IEnumerator FlashObj()
    {
        Color col = outlinedObject.GetComponent<Image>().color;
        outlinedObject.GetComponent<Image>().color = new Color(col.r, col.g, col.b, 1f);
        yield return new WaitForSeconds(0.2f);
        while (true)
        {
            if (outlinedObject.GetComponent<Image>().color.a == 0f)
            {
                outlinedObject.GetComponent<Image>().color = new Color(col.r, col.g, col.b, 1f);
            }
            else
            {
                outlinedObject.GetComponent<Image>().color = new Color(col.r, col.g, col.b, 0f);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(0.1f);

        gElements.dubbio.fillAmount += (1f / 180f);

        if (notTouch == true)
            StartCoroutine(Time());
    }

    IEnumerator Action ()
    {
        yield return new WaitForSeconds(2);

        notTouch = false;

        StopCoroutine("FlashObj");
        outlinedObject.SetActive(false);
        
        active = true;
        this.GetComponent<Button>().interactable = false;
        
	}


	
	
	public void OnMouseDown ()
    {
        notTouch = false;
        active = true;
        StopCoroutine(Action());
        
        StopCoroutine(FlashObj());
        outlinedObject.SetActive(false);
        this.GetComponent<Button>().interactable = false;
        sElements.PlaySound(0);
        ispirazione.SetActive(false);

    }
}
