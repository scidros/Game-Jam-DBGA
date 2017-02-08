using UnityEngine;
using System.Collections;

public class Actions : MonoBehaviour {

    public Employee employee;
    public GameObject azioni;

	public void Mangiare ()
    {
         StartCoroutine(Eat());
         azioni.SetActive(false);
     
    }
	
	
	IEnumerator Eat ()
    {
        employee.moltiplicatore = 0;

        yield return new WaitForSeconds(10);
        

        if (employee.myProductivity <= 0.01f)
        {
            employee.moltiplicatore = 1;
            employee.myProductivity = 1;
            employee.Productivity.fillAmount = 1;
            employee.Product();
        }
        else
            employee.myProductivity = 1;



    }

    
}
