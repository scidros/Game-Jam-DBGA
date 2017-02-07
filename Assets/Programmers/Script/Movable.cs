using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movable : MonoBehaviour {

    
    public Transform start;
    public Transform end;
    Transform targetTr;
    public float speed = 1;
    public Text text;
    private bool enabledText = true;


    public bool activate = false;

    void Start ()
    {
        targetTr = end;
	}
	
    IEnumerator TextVisualization()
    {
        text.gameObject.SetActive(true);

        yield return new WaitForSeconds(3);

        text.gameObject.SetActive(false);
    }
	
	void Update ()
    {
        if (activate == true)
        {
            if (text != null && enabledText == true)
            {
                StartCoroutine(TextVisualization());
                enabledText = false;
            }
                


            Vector3 distance = targetTr.position - this.transform.position;
            Vector3 direction = distance.normalized;

            transform.position = transform.position + direction * 10 * speed * Time.deltaTime;

            if (distance.magnitude < 0.5f)
            {
                transform.position = targetTr.position;
                if (targetTr == end)
                    targetTr = start;
                else
                    targetTr = end;

                activate = false;

            }
        }

    }
}
