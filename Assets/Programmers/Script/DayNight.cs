using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayNight : MonoBehaviour {

    
    public Image day;
    public Image night1;
    public Image night2;
    public Image night3;

    private MusicManager musicManager;
    

    void Start ()
    {
        musicManager = FindObjectOfType<MusicManager>();
        StartCoroutine(Cycle());
	}
	
	
	IEnumerator Cycle ()
    {
        yield return new WaitForSeconds(75);
        day.gameObject.SetActive(false);
        night1.gameObject.SetActive(true);
        night2.gameObject.SetActive(true);
        night3.gameObject.SetActive(true);

        yield return new WaitForSeconds(65);
        day.gameObject.SetActive(true);
        night1.gameObject.SetActive(false);
        night2.gameObject.SetActive(false);
        night3.gameObject.SetActive(false);

        yield return new WaitForSeconds(75);
        day.gameObject.SetActive(false);
        night1.gameObject.SetActive(true);
        night2.gameObject.SetActive(true);
        night3.gameObject.SetActive(true);

        yield return new WaitForSeconds(65);
        musicManager.PlayMusic(2);
        day.gameObject.SetActive(true);
        night1.gameObject.SetActive(false);
        night2.gameObject.SetActive(false);
        night3.gameObject.SetActive(false);
    }
}
