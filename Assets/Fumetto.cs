using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fumetto : MonoBehaviour {

    public Employee employee;
    GameController gElements;
    
    SoundManager sElements;
    Color col;

    void Awake ()
    {
        
        gElements = FindObjectOfType<GameController>();
        sElements = FindObjectOfType<SoundManager>();
        col = this.GetComponent<Image>().color;
        
    }

	public void startNuvola ()
    {
        col.a = 1;
        this.GetComponent<Image>().color = col;

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
        if (col.a < 1)
        {
            col.a += 0.1f;
            this.GetComponent<Image>().color = col;
        }


        gElements.dubbio.fillAmount += col.a / 100f;

       

    }


    public void Decrease ()
    {
            sElements.PlaySound(7);
            
            
            col.a -= 0.1f;
            


        if (col.a <= 0.1f)
            {
                employee.DubbioStart();
                this.StopAllCoroutines();
                employee.activeEvents = true;
                this.gameObject.SetActive(false);
            }
            else
                this.GetComponent<Image>().color = col;
    }
}
