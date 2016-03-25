using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {

    private float timeLeft = 0.5f;
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            Destroy(gameObject);
        }
	}
}
