using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GiveNameToText : MonoBehaviour {

	private Text text;
    ModeManager modeManager;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
        modeManager = FindObjectOfType<ModeManager>();
    }
	
	// Update is called once per frame
	void Update () {
		text.text = modeManager.gameName;
	}
}
