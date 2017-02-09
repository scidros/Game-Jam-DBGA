using UnityEngine;
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

	public Difficolta difficolta;
	public string gameName;
    
	void Start ()
    {
        ModeManager[] modeManager = FindObjectsOfType<ModeManager>();
        if (modeManager.Length > 1)
        {
            Destroy(modeManager[1].gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
		badMatchWords = new List<string> ();
        TextAsset ta = Resources.Load<TextAsset>("video_game_names");

        string completeFile = ta.text;
		AssignWords (completeFile);
	}

	private void AssignWords(string source)
	{
		int i = 0;
		string[] allWords = source.Split ('\n');

		stringList = new Dictionary<int, List<string>>();

		stringList.Add (i, new List<string> ());

		foreach (string word in allWords) 
		{

			if (word.Contains("----")) 
			{
				i++;
				stringList.Add (i, new List<string>());
				continue;
			}

			stringList [i].Add (word);
		}
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
	}


}
