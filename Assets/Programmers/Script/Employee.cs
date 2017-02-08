using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Employee : MonoBehaviour {

    public GameObject actions;
    public Image Productivity;
    public float mySkill;
    public float myProductivity = 0.5f;
    Actions actionsElements;


    void Start()
    {
        mySkill = Random.Range(0.40f, 0.60f);
        mySkill = (float)System.Math.Round(mySkill, 2);
        Productivity.fillAmount = myProductivity;
        StartCoroutine(Produttività());
        actionsElements = FindObjectOfType<Actions>();
    }

    public void Product()
    {
        StartCoroutine(Produttività());
    }

    public IEnumerator Produttività()
    {
        yield return new WaitForSeconds(1);

        myProductivity -= 0.01f;
        Productivity.fillAmount = myProductivity;
        if (myProductivity > 0)
            StartCoroutine(Produttività());
    }

	void OnMouseDown ()
    {
        actions.SetActive(true);

        actionsElements.employee = this.GetComponent<Employee>();
	}
}
