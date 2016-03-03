using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sceneManage : MonoBehaviour {

    public GameObject deathPanel;
    public GameObject victoryPanel;

    public Text timerText;
    public float timeLeft = 99f;

    void Start()
    {
        timerText.text = timeLeft.ToString();
    }

    public void playerDeath()
    {
        Time.timeScale = 0f;
        deathPanel.SetActive(true);
    }
    public void playerVictory()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = Mathf.RoundToInt(timeLeft).ToString();
        if (timeLeft < 0)
        {
            Time.timeScale = 0f;
            victoryPanel.SetActive(true);
        }

        if(timeLeft <= 50f)
        {
            //add difficulty after 50 secs
            GameObject.Find("EnemyBase2").GetComponent<generateEnemyMinion>().enabled = true;
        }


    }

}
