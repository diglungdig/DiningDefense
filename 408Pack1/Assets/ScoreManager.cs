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
		if(PlayerPrefs.HasKey("NAME")){
			name = PlayerPrefs.GetString("NAME");
		}
		if(PlayerPrefs.HasKey("SCORE")){
			score = PlayerPrefs.GetString("SCORE");
			SetScore (name, "score", score);
		}
		if(PlayerPrefs.HasKey("DATE")){
			date = PlayerPrefs.GetString("DATE");
			SetScore (name, "date", date);
		}


		SetScore ("Mason", "score", "9001");
		SetScore ("Mason", "date", "2/16/2016");
		SetScore ("Bob", "score", "1");
		SetScore ("Bob", "date", "2/13/2016");
		SetScore ("John Cena", "score", "5");
		SetScore ("John Cena", "date", "2/18/2016");
		Debug.Log (GetScore ("Mason","score"));
	}

	public void Init() {
		if (playerScores != null)
			return;
		playerScores = new Dictionary<string, Dictionary<string,string>>();
	}

	public void RemoveScore (string username){
		playerScores.Remove (username);
	}

	public void ClearScores(){
		playerScores.Clear ();
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