using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [Header("Play Button Parameters")]
    public float playButtonDecreaseDoubtAmount = 0.01f;
    public float playButtonSecondsToWaitBeforeTimerIncrease = 1f;
    public int playButtonTimerMaximumLimit = 20;

    [Header("Employee Parameters")]
    public int[] multiplier = new int[3] { 0, 1, 2 };

    [Header("Toon Parameters")]
    public float inspirationToonDeactivationWaitingTime = 2f;
    public float doubtCloudIncreaseWaitingTime = 1f;
    public float doubtCloudLocalScaleMaximumLimit = 1f;
    public float doubtCloudLocalScaleIncreaseValue = 0.1f;

    [Header("ObjectTap Parameters")]
    public float objTapDivide = 180f;

    [Header("ObjectTap Parameters")]
    public float fumettoDivide = 180f;

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
    MusicManager mElements;
	
    void Start()
    {
        StartCoroutine(Project());
        StartCoroutine(TimeBar());
        modeManager = FindObjectOfType<ModeManager>();
        mElements = FindObjectOfType<MusicManager>();

        if (modeManager)
        {
            string suffix = "";
            switch ((int)modeManager.difficolta)
            {
                case 0:
                    suffix = " (Endless Run)";
                    break;
                case 1:
                    suffix = " (Shooter)";
                    break;
                case 2:
                    suffix = " (MMORPG)";
                    break;
            }
            title.text = modeManager.gameName + suffix;
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
        {
            mElements.PlayMusic(3);
            SceneManager.LoadScene("GameOver");
        }

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
        {
            mElements.PlayMusic(3);
            SceneManager.LoadScene("YouWin");
        }

        yield return new WaitForSeconds(1);

        foreach (var impiegato in impigati)
        {
            progetto.fillAmount += (impiegato.mySkill * impiegato.myProductivity * impiegato.moltiplicatore) / (progressMod * diffMod);
        }

        StartCoroutine(Project());
    }

    void Update()
    {
        if (dubbio.fillAmount >= 1)
        {
            mElements.PlayMusic(3);
            SceneManager.LoadScene("GameOver");

        }
            
    }
	

}
