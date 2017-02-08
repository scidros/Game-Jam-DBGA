using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Image progetto;
    public Image dubbio;
    public Text time;
    public Text title;
    public int progressMod;
    public int timer = 300;
    public float[] difficultyMod;
    public List<Employee> impigati;

    private ModeManager modeManager;
    private float diffMod;
	
    void Start()
    {
        StartCoroutine(Project());
        StartCoroutine(TimeBar());
        modeManager = FindObjectOfType<ModeManager>();
        if (modeManager)
        {
            title.text = modeManager.gameName;
            diffMod = difficultyMod[(int)modeManager.difficolta];
        }
        else
        {
            diffMod = 1;
        }
    }

	IEnumerator TimeBar ()
    {
        if (timer <= 0)
            Debug.Log("sconfitta");

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
            Debug.Log("Vittoria");

        yield return new WaitForSeconds(1);

        foreach (var impiegato in impigati)
        {
            progetto.fillAmount += (impiegato.mySkill * impiegato.myProductivity * impiegato.moltiplicatore) / (progressMod * diffMod);
        }

        StartCoroutine(Project());
    }

    
	

}
