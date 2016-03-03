using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class reloadLevel : MonoBehaviour {


    public void reload()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
