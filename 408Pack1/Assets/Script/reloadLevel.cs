using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class reloadLevel : MonoBehaviour {
	
	public InputField nameField;
	public Text Score;

	public void reload()
	{
		string name = "temp";
		string date = "temp";
		string score = "0";
		Debug.Log(nameField.text.ToString());
		if (nameField.text.ToString () != null)
			name = nameField.text.ToString ();
		else
			Debug.Log ("Name missing");
		Debug.Log(System.DateTime.Now.ToString());
		if(System.DateTime.Now.ToString() != null)
			date = System.DateTime.Now.ToString();
		else
			Debug.Log ("Time missing");
		Debug.Log(Score.text.Substring (7));
		Debug.Log(Score.text.Substring (7));
		if(Score.text.Substring (7) != null)
			score =  Score.text.Substring (7);  
		else
			Debug.Log ("Score missing");
		
		bool found = false;
		if (name != "temp" && score != "temp" && score != "0") {
			for (int i = 1; i <= 5; i++) {
				if (!found) {
					Debug.Log ("Checking if score " + i + " exists");
					if (PlayerPrefs.HasKey ("SCORE" + i)) {
						Debug.Log ("Score " + i + " exists");
						if (int.Parse (score) > int.Parse (PlayerPrefs.GetString ("SCORE" + i))) {
							for (int j = i + 1; j < 5; j++) {
								if (PlayerPrefs.HasKey ("SCORE" + (j - 1))) {
									PlayerPrefs.SetString ("NAME" + j, PlayerPrefs.GetString ("NAME" + (j - 1)));
									PlayerPrefs.SetString ("DATE" + j, PlayerPrefs.GetString ("DATE" + (j - 1)));
									PlayerPrefs.SetString ("SCORE" + j, PlayerPrefs.GetString ("SCORE" + (j - 1)));
								}
							}
							PlayerPrefs.SetString ("NAME" + i, name);
							PlayerPrefs.SetString ("DATE" + i, date);
							PlayerPrefs.SetString ("SCORE" + i, score);
							Debug.Log ("Added score for " + name + " at " + i);
							found = true;
						}
					} else {
						PlayerPrefs.SetString ("NAME" + i, name);
						PlayerPrefs.SetString ("DATE" + i, date);
						PlayerPrefs.SetString ("SCORE" + i, score);
						Debug.Log ("Added score for " + name + " at " + i);
						found = true;
					}
				}
			}
		}

		Time.timeScale = 1f;
		SceneManager.LoadScene(1);
	}
}