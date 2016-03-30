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
			date = System.DateTime.MaxValue.ToString();
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
			PlayerPrefs.SetString ("NAME", PlayerPrefs.GetString ("NAME"));
			PlayerPrefs.SetString ("DATE", PlayerPrefs.GetString ("DATE"));
			PlayerPrefs.SetString ("SCORE", PlayerPrefs.GetString ("SCORE"));
		}
			
		SceneManager.LoadScene(1);
	}
}
