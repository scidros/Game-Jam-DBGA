using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Popup : MonoBehaviour {

    public MainMenu mainMenu;
    private Transform btnBack;

    public void TogglePopup()
    {
        gameObject.SetActive(true);
        StartCoroutine("TogglePopupCoroutine");
    }

    public IEnumerator TogglePopupCoroutine()
    {
        btnBack = transform.Find("btnBack");
        mainMenu = FindObjectOfType<MainMenu>();
        CanvasGroup panelCanvas = GetComponent<CanvasGroup>();
        bool opening;
        if (panelCanvas.alpha == 0)
        {
            opening = true;
        }
        else
        {
            opening = false;
        }
        if (btnBack)
        {
            btnBack.GetComponent<Button>().interactable = false;
        }
        float elapsedTime = 0;
        gameObject.SetActive(true);
        if (GetComponent<Button>())
        {
            GetComponent<Button>().interactable = false;
        }
        while (elapsedTime < mainMenu.fadeTime)
        {
            elapsedTime += Time.deltaTime;
            if (opening)
            {
                panelCanvas.alpha = Mathf.Lerp(0f, 1f, (elapsedTime / mainMenu.fadeTime));
            }
            else
            {
                panelCanvas.alpha = Mathf.Lerp(1f, 0f, (elapsedTime / mainMenu.fadeTime));
            }
            yield return null;
        }
        if (GetComponent<Button>())
        {
            GetComponent<Button>().interactable = true;
        }
        if (btnBack)
        {
            btnBack.GetComponent<Button>().interactable = true;
        }
        if (!opening)
        {
            gameObject.SetActive(false);
        }
    }
}
