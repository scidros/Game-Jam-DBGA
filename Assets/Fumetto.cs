using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fumetto : MonoBehaviour {

    public Employee employee;
    GameController gElements;
    RectTransform rt;

    void Start ()
    {
        rt = GetComponent <RectTransform>();
        gElements = FindObjectOfType<GameController>();
    }

	public void startNuvola ()
    {
        StartCoroutine(Nuvola());
	   
	}

    public void startIspirazione()
    {
        StartCoroutine(Ispirazione());

    }

    IEnumerator Ispirazione()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    IEnumerator Nuvola()
    {
        yield return new WaitForSeconds(1);
        Increase();
        StartCoroutine(Nuvola());

    }

    void Increase ()
    {
        if (rt.localScale.x < 1f)
        {
            Vector3 sc = rt.localScale;
            sc.x += 0.1f;
            sc.y += 0.1f;

            if (sc.x > 1f)
                rt.localScale = new Vector3(1f, 1f);
            else
                rt.localScale = sc;
        }

        gElements.dubbio.fillAmount += rt.localScale.x / 100f;
    }


    public void Decrease ()
    {
            Vector3 sc = rt.localScale;
            sc.x -= 0.2f;
            sc.y -= 0.2f;

            if (sc.x <= 0f)
            {
                rt.localScale = new Vector3(1f, 1f);
                employee.DubbioStart();
                this.StopAllCoroutines();
                employee.activeEvents = true;
                this.gameObject.SetActive(false);
            }
            else
                rt.localScale = sc;
    }
}
