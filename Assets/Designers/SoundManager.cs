using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    public List<GameObject> soundObjects;
    
	void Start ()
    {
        SoundManager[] soundManager = FindObjectsOfType<SoundManager>();
        if (soundManager.Length > 1)
        {
            Destroy(soundManager[1].gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        foreach (Transform soundObject in gameObject.transform)
        {
            soundObjects.Add(soundObject.gameObject);
        }
    }

    public void PlaySound(int n)
    {
        soundObjects[n].GetComponent<AudioSource>().Play();
    }
}