using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Image progetto;
    public int moltiplicatore = 1;
    public List<Employee> impigati;
	
    void Start()
    {
        StartCoroutine(Project());
    }

	IEnumerator TimeBar ()
    {
        progetto.fillAmount -= 0.0033333333333333f;

        Debug.Log("ciao");

        yield return new WaitForSeconds(1);
        if (progetto.fillAmount > 0)
            StartCoroutine(TimeBar());
	}
	
    IEnumerator Project()
    {
        yield return new WaitForSeconds(1);

        foreach (var impiegato in impigati)
        {
            progetto.fillAmount += (impiegato.mySkill * impiegato.myProductivity * moltiplicatore) / 100;
        }

        StartCoroutine(Project());
    }

	
	void Update () {
	
	}
}
