using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour {

    public List<GameObject> musicObjects;
    
	void Start ()
    {
        MusicManager[] musicManager = FindObjectsOfType<MusicManager>();
        if (musicManager.Length > 1)
        {
            Destroy(musicManager[0].gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        foreach (Transform musicObject in gameObject.transform)
        {
            musicObjects.Add(musicObject.gameObject);
        }
    }

    public void PlayMusic(int n)
    {
        foreach (Transform musicObject in gameObject.transform)
        {
            musicObject.GetComponent<AudioSource>().Stop();
        }
        musicObjects[n].GetComponent<AudioSource>().Play();
    }
}