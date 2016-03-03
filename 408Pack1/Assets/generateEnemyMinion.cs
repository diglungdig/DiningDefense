using UnityEngine;
using System.Collections;
using foodDefense;

public class generateEnemyMinion : MonoBehaviour {

	public GameObject[] enemyMinions;
	[SerializeField] private int enemyDifficulty = 1;

	public Sprite[] sprites;

	private float startTime = 0f;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
		startTime += Time.deltaTime;
		if(startTime >= 5){
			GameObject enemy = (GameObject)Instantiate (enemyMinions [0], gameObject.transform.position, Quaternion.Euler (0f, 0f, 0f));
			enemy.GetComponent<SpriteRenderer> ().sprite = sprites [Random.Range (0, 6)];
			startTime = 0f;
		}
}
}