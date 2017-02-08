﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ModeManager : MonoBehaviour {

	public enum Difficolta
	{
		easy, medium, hard
	};

	Dictionary<int,List<string>> stringList;
	List<string> badMatchWords;

	public static Difficolta difficolta;
	public static string gameName;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		badMatchWords = new List<string> ();
        TextAsset ta = Resources.Load<TextAsset>("video_game_names");

        string completeFile = ta.text;
		AssignWords (completeFile);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void AssignWords(string source)
	{
		int i = 0;
		string[] allWords = source.Split ('\n');
		Debug.Log (allWords.Length);

		stringList = new Dictionary<int, List<string>>();

		stringList.Add (i, new List<string> ());

		foreach (string word in allWords) 
		{

			if (word.Contains("----")) 
			{
                Debug.Log("FOUND ---");
				i++;
				stringList.Add (i, new List<string>());
				continue;
			}

			stringList [i].Add (word);
		}
		Debug.Log (i);
	}

	public string DecideWord(int index)
	{
		string currentWord;
		bool canGoOn = false;

		do 
		{
			
			int random = Random.Range (0, stringList [index].Count);
			currentWord = stringList[index][random];

			if(badMatchWords != null){
				if(currentWord.IndexOf('^') != -1)
					canGoOn = CompareWithBadMatch(currentWord.Split('^')[0]);
				else
					canGoOn = CompareWithBadMatch(currentWord);
			}

			else 
				canGoOn = true;
		} 
		while(!canGoOn);

		badMatchWords.Add (currentWord);
		if (currentWord.IndexOf ('^') != -1)
			return currentWord.Split ('^') [0];
		else
			return currentWord;

	}

	bool CompareWithBadMatch(string toCompare)
	{
		for (int i = 0; i < badMatchWords.Count; i++) 
		{
			if (badMatchWords [i].Contains (toCompare))
				return false;
		}
		return true;
	}

	public void ComposeName()
	{
		gameName = DecideWord (0) + " " + DecideWord (1) + " " + DecideWord (2);
		badMatchWords.Clear ();
	}

	public void AssegnaDifficolta(int diff)
	{
		difficolta = (Difficolta)diff;
		Debug.Log (difficolta);
	}


}
