using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class Employee : MonoBehaviour {

    public GameObject actions;
    public Image Productivity;
    public float mySkill;
    public float myStamina;
    public float myProductivity = 0.5f;
    Actions actionsElements;
    public int moltiplicatore = 1;
    public int mioDubbio = 10;
    GameController gElements;
    public Image fumetto;
    public Image ispirazione;
    public bool activeEvents = true;
    private bool activePause = true;
    public bool activeBoost = true;
    public GameObject play;
    ObjectsContainer objContainer;


    void Start()
    {
        mySkill = Random.Range(0.40f, 0.60f);
        mySkill = (float)System.Math.Round(mySkill, 2);
        myStamina = Random.Range(0.9f, 1.1f);
        myStamina = (float)System.Math.Round(myStamina, 2);
        Productivity.fillAmount = myProductivity;
        StartCoroutine(Produttività());
        actionsElements = FindObjectOfType<Actions>();
        gElements = FindObjectOfType<GameController>();
        StartCoroutine(Dubbio());
        objContainer = FindObjectOfType<ObjectsContainer>();
    }

    public void Product()
    {
        StartCoroutine(Produttività());
    }

    public IEnumerator Produttività()
    {
        yield return new WaitForSeconds(1);

        myProductivity -= 0.01f * myStamina;
        Productivity.fillAmount = myProductivity;
        if (myProductivity > 0)
            StartCoroutine(Produttività());
    }

	public void OnMouseDown ()
    {
        actions.SetActive(true);

        actionsElements.employee = this.GetComponent<Employee>();

        if (this.gameObject.name == "E1")
            actions.GetComponent<HideButtons>().State1();
        else if (this.gameObject.name == "E2")
            actions.GetComponent<HideButtons>().State2();
        else if (this.gameObject.name == "E3")
            actions.GetComponent<HideButtons>().State3();
    }

    public void HideMyButtons()
    {
        if (this.gameObject.name == "E1")
            actions.SetActive(false);
        else if (this.gameObject.name == "E2")
            actions.SetActive(false);
        else if (this.gameObject.name == "E3")
            actions.SetActive(false);
    }

    public void Mangiare()
    {
        StartCoroutine(Eat());
        actions.SetActive(false);

    }


    IEnumerator Eat()
    {
        moltiplicatore = 0;

        yield return new WaitForSeconds(10);


        if (myProductivity <= 0.01f)
        {
            moltiplicatore = 1;
            myProductivity = 1;
            Productivity.fillAmount = 1;
            Product();
        }
        else
            myProductivity = 1;

    }

    public void DubbioStart()
    {
        StartCoroutine(Dubbio());
    }

    IEnumerator Dubbio()
    {
        yield return new WaitForSeconds(mioDubbio + Random.Range(0, 9));

        while (moltiplicatore == 0)
            yield return null;

        Evento(Random.Range(1, 3));
        if (activeEvents == true)
            StartCoroutine(Dubbio());
        
    }

    public void Evento(int nDubbio)
    {
        gElements.dubbio.fillAmount += 0.01f;

        switch (nDubbio)
        {
            case 1:
                fumetto.gameObject.SetActive(true);
                fumetto.GetComponent<Fumetto>().startNuvola();
                activeEvents = false;
                break;
            case 2:
                objContainer.ActiveAnObject();
                ispirazione.gameObject.SetActive(true);
                ispirazione.GetComponent<Fumetto>().startIspirazione();
                break;
        }
    }

    public void Pause()
    {
        HideMyButtons();
        play.SetActive(true);
        moltiplicatore = 0;
        play.GetComponent<Play>().PlayStart();
    }

    public void BoostStart()
    {
        if (activeBoost == true)
            {
            HideMyButtons();
            StartCoroutine(BoostEnable());
            activeBoost = false;
            }
        
    }

    IEnumerator BoostEnable()
    {
        moltiplicatore = 2;

        yield return new WaitForSeconds(10);

        moltiplicatore = 1;
        activeBoost = true;

    }




}
