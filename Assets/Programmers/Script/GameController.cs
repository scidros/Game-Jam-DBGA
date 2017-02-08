using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Image progetto;
    public Image dubbio;
    public Text time;
    public int timer = 300;
    
    public List<Employee> impigati;
	
    void Start()
    {
        StartCoroutine(Project());
        StartCoroutine(TimeBar());
    }

	IEnumerator TimeBar ()
    {
        if (timer <= 0)
            SceneManager.LoadScene("GameOver");

        time.text = timer.ToString();
        timer--;

        

        yield return new WaitForSeconds(1);
        if (timer >= 0)
            StartCoroutine(TimeBar());
        else
            time.text = "0";
    }
	
    IEnumerator Project()
    {
        if (progetto.fillAmount >= 1)
            SceneManager.LoadScene("YouWin");

        yield return new WaitForSeconds(1);

        foreach (var impiegato in impigati)
        {
            progetto.fillAmount += (impiegato.mySkill * impiegato.myProductivity * impiegato.moltiplicatore) / 100;
        }

        StartCoroutine(Project());
    }

    
	

}
