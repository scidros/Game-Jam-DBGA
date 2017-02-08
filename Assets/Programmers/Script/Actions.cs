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
        yield return new WaitForSeconds(10);
        

        if (employee.myProductivity <= 0.01f)
        {
            employee.myProductivity = 1;
            employee.Productivity.fillAmount = 1;
            employee.Product();
        }
        else
            employee.myProductivity = 1;



    }

    
}
