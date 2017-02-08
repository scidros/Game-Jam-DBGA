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
        gElements.dubbio.fillAmount -= 0.01f;

        yield return new WaitForSeconds(1);
        timer++;

        if (timer < 20)
            StartCoroutine(PlayMode());
        else
        {
            myEmployee.moltiplicatore = 1;
            this.gameObject.SetActive(false);
        }
     
    }

    public void PlayStart()
    {
        StartCoroutine(PlayMode());
    }

    public void Stop()
    {
        myEmployee.moltiplicatore = 1;
        this.gameObject.SetActive(false);
        
    }
}
