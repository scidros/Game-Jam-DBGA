using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

    GameController gElements;
    public Employee myEmployee;
    int timer = 0;

    void Awake()
    {
        gElements = FindObjectOfType<GameController>();
        StartCoroutine(PlayMode());
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
        }
     
    }

    public void PlayStart()
    {
        StartCoroutine(PlayMode());
    }

    public void Stop()
    {
        myEmployee.moltiplicatore = gElements.multiplier[1];
        this.gameObject.SetActive(false);
        
    }
}
