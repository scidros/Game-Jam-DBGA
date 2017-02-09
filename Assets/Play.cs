using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Play : MonoBehaviour {

    GameController gElements;
    public Employee myEmployee;
    int timer = 0;
    SoundManager sElements;

    void Awake()
    {
        gElements = FindObjectOfType<GameController>();
        StartCoroutine(PlayMode());
        sElements = FindObjectOfType<SoundManager>();

    }

    IEnumerator PlayMode()
    {
        gElements.dubbio.fillAmount -= gElements.playButtonDecreaseDoubtAmount;

        yield return new WaitForSeconds(gElements.playButtonSecondsToWaitBeforeTimerIncrease);
        timer++;

        if (timer < gElements.playButtonTimerMaximumLimit)
            StartCoroutine(PlayMode());
        else
        {
            myEmployee.moltiplicatore = gElements.multiplier[1];
            this.gameObject.SetActive(false);
            Color col = myEmployee.GetComponent<Image>().color;
            col.a = 1;
            myEmployee.GetComponent<Image>().color = col;
        }
     
    }

    public void PlayStart()
    {


        StartCoroutine(PlayMode());

        Color col = myEmployee.GetComponent<Image>().color;
        col.a = 0.5f;
        myEmployee.GetComponent<Image>().color = col;
    }

    public void Stop()
    {
        sElements.PlaySound(3);

        myEmployee.moltiplicatore = gElements.multiplier[1];
        this.gameObject.SetActive(false);

        Color col = myEmployee.GetComponent<Image>().color;
        col.a = 1;
        myEmployee.GetComponent<Image>().color = col;

    }
}
