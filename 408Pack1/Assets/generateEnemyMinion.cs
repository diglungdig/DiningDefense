using UnityEngine;
using System.Collections;
using foodDefense;

public class generateEnemyMinion : MonoBehaviour {

	public GameObject[] enemyMinions;
	[SerializeField] private int enemyDifficulty = 1;

	private float startTime = 0f;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
		startTime += Time.deltaTime;
		if(startTime >= 5){
			Instantiate (enemyMinions [0], gameObject.transform.position, Quaternion.Euler (90f, 180f, 180f));
			startTime = 0f;
		}
}
}