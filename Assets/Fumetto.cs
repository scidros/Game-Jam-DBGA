using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fumetto : MonoBehaviour {

    public Employee employee;
    GameController gElements;
    RectTransform rt;
    SoundManager sElements;

    void Awake ()
    {
        rt = GetComponent <RectTransform>();
        gElements = FindObjectOfType<GameController>();
        sElements = FindObjectOfType<SoundManager>();
    }

	public void startNuvola ()
    {
        sElements.PlaySound(6);
        StartCoroutine(Nuvola());
	   
	}

    public void startIspirazione()
    {
        StartCoroutine(Ispirazione());

    }

    IEnumerator Ispirazione()
    {
        sElements.PlaySound(6);
        yield return new WaitForSeconds(gElements.inspirationToonDeactivationWaitingTime);
        gameObject.SetActive(false);
    }

    IEnumerator Nuvola()
    {
        
        yield return new WaitForSeconds(gElements.doubtCloudIncreaseWaitingTime);
        Increase();
        StartCoroutine(Nuvola());

    }

    void Increase ()
    {
        if (rt.localScale.x < gElements.doubtCloudLocalScaleMaximumLimit)
        {
            Vector3 sc = rt.localScale;
            sc.x += gElements.doubtCloudLocalScaleIncreaseValue;
            sc.y += gElements.doubtCloudLocalScaleIncreaseValue;

            if (sc.x > 1f)
                rt.localScale = new Vector3(gElements.doubtCloudLocalScaleMaximumLimit, gElements.doubtCloudLocalScaleMaximumLimit);
            else
                rt.localScale = sc;
        }

        gElements.dubbio.fillAmount += rt.localScale.x / 100f;
    }


    public void Decrease ()
    {
            sElements.PlaySound(7);
            
            Vector3 sc = rt.localScale;
            sc.x -= 0.2f;
            sc.y -= 0.2f;

            if (sc.x <= 0.1f)
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
