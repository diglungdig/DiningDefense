using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class reloadLevel : MonoBehaviour {

	public InputField nameField;
	public Text Score;

    public void reload()
    {
		if (nameField.text.ToString () != null)
			PlayerPrefs.SetString ("NAME", nameField.text.ToString ());
		else
			Debug.Log (nameField.text.ToString ());
		if(System.DateTime.Now.ToString() != null)
			PlayerPrefs.SetString ("DATE", System.DateTime.Now.ToString());
		else
			Debug.Log (System.DateTime.Now.ToString());
		if(Score.text.Substring (6) != null)
			PlayerPrefs.SetString ("SCORE", Score.text.Substring (6));  
		else
			Debug.Log (Score.text.Substring (6));
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
