using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScoreManager : MonoBehaviour {

	Dictionary<string, Dictionary<string, string>> playerScores; 
	string name = "";
	string score = "";
	string date = "";

	void Awake() {
		//ClearScores ();
		for (int i = 1; i <= 5; i++) {
			if (PlayerPrefs.HasKey ("NAME" + i)) {
				name = PlayerPrefs.GetString ("NAME" + i);
				Debug.Log (i + " name is " + name);
			}
			if (PlayerPrefs.HasKey ("SCORE" + i)) {
				score = PlayerPrefs.GetString ("SCORE" + i);
				SetScore (name, "score", score);
				Debug.Log (i + " score is " + score);
			}
			if (PlayerPrefs.HasKey ("DATE" + i)) {
				date = PlayerPrefs.GetString ("DATE" + i);
				SetScore (name, "date", date);
			}
		}

		/*
		SetScore ("Mason", "score", "9001");
		SetScore ("Mason", "date", "2/16/2016");
		SetScore ("Bob", "score", "1");
		SetScore ("Bob", "date", "2/13/2016");
		SetScore ("John Cena", "score", "5");
		SetScore ("John Cena", "date", "2/18/2016");
		*/
		Debug.Log (name);
		Debug.Log (GetScore (name,"score"));
	}

	public void Init() {
		if (playerScores != null)
			return;
		playerScores = new Dictionary<string, Dictionary<string,string>>();
	}

	public void RemoveScore (string username){
		playerScores.Remove (username);
	}

	public static void ClearScores(){
		//playerScores.Clear ();
	}

	public string GetScore(string username, string scoreType) {
		Init ();
		if (playerScores.ContainsKey (username) == false) {
			return "";
		}
		if(playerScores[username].ContainsKey(scoreType) == false)
			return "";
		return playerScores [username][scoreType];
	}

	public void SetScore(string username, string scoreType, string value) {
		Init ();
		if (playerScores.ContainsKey (username) == false) {
			playerScores [username] = new Dictionary<string, string> ();
		}
		playerScores [username][scoreType] = value;
	} 

	public string[] getPlayerNames(){
		Init ();
		return playerScores.Keys.ToArray ();
	}
}