using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class pauseScript : MonoBehaviour {

	public GameObject startText;
	public GameObject exitText;
	public GameObject highScoresText;
	public GameObject settingsText;
	public GameObject pauseTitle;

	public GameObject quitMenu;
	public GameObject pauseMenu;
	public GameObject scoresMenu;
	public GameObject settingsMenu;


	// Use this for initialization
	void Start () {
		quitMenu.SetActive (false);
		pauseMenu.SetActive (false);
		scoresMenu.SetActive (false);
		settingsMenu.SetActive (false);
	}

	public void ReturnToPauseMenu(){
		quitMenu.SetActive (false);
		pauseMenu.SetActive (true);

		startText.SetActive (true);
		exitText.SetActive (true);
		highScoresText.SetActive (true);
		settingsText.SetActive (true);
		pauseTitle.SetActive (true);
	}

	public void ExitPress(){
		
		pauseMenu.SetActive (false);
		scoresMenu.SetActive (false);
		settingsMenu.SetActive (false);
		quitMenu.SetActive (true);
	}

	public void NoPress(){
		quitMenu.SetActive (false);
		startText.SetActive(true);
		exitText.SetActive(true);
	}

	public void StartLevel(){
		quitMenu.SetActive (false);
		pauseMenu.SetActive (false);
		scoresMenu.SetActive (false);
		settingsMenu.SetActive (false);

		Time.timeScale = 1;
	}

	public void ShowHighScores(){
		startText.SetActive(false);
		exitText.SetActive(false);
		highScoresText.SetActive(false);
		settingsText.SetActive(false);
		pauseTitle.SetActive (false);

		scoresMenu.SetActive (true);
	}

	public void ShowSettings(){
		startText.SetActive(false);
		exitText.SetActive(false);
		highScoresText.SetActive(false);
		settingsText.SetActive(false);
		pauseTitle.SetActive (false);

		settingsMenu.SetActive (true);
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void PauseGame(){
		pauseMenu.SetActive(true);
		Time.timeScale = 0;
	}
}
