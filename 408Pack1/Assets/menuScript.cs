using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;
	public Button highScoresText;
	public Button settingsText;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		highScoresText = highScoresText.GetComponent<Button> ();
		settingsText = settingsText.GetComponent<Button> ();
		quitMenu.enabled = false;
	}
	
	public void ExitPress(){
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress(){
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void StartLevel(){
		SceneManager.LoadScene (1);
	}

	public void ShowHighScores(){
		SceneManager.LoadScene (2);
	}

	public void ShowSettings(){
		SceneManager.LoadScene (3);
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
