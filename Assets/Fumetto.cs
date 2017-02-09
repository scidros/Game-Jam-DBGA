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

<<<<<<< HEAD
        gElements.dubbio.fillAmount += col.a / 100f;
=======
        gElements.dubbio.fillAmount += rt.localScale.x / 150f;
>>>>>>> 922b91fa0e0d0d725a5d5cc3a2fbcd54fd9b5843
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
