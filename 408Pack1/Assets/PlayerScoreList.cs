using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;

	ScoreManager scoreManager; 

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.FindObjectOfType<ScoreManager>();

		string[] names = scoreManager.getPlayerNames ();
		int i, j;
		for (i = 0; i < names.Length-1; i++) {
			for (j = i + 1; j < names.Length; j++) {
				if (Convert.ToInt32 (scoreManager.GetScore (names [i], "score")) <
					Convert.ToInt32 (scoreManager.GetScore (names [j], "score"))) {
					string temp = names[i];
					names [i] = names [j];
					names [j] = temp;
				}
			}
		}
		int k = 1;
		foreach(string name in names){
			GameObject go = (GameObject)Instantiate (playerScoreEntryPrefab);
			go.transform.SetParent (this.transform);
			go.transform.Find ("Player").GetComponent<Text> ().text = name;
			go.transform.Find ("Score").GetComponent<Text> ().text = scoreManager.GetScore(name,"score");
			go.transform.Find ("Date").GetComponent<Text> ().text = scoreManager.GetScore (name, "date");
			go.transform.Find ("Rank").GetComponent<Text> ().text = k.ToString();
			k++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
