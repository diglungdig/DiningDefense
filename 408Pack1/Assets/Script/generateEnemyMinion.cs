using UnityEngine;
using System.Collections;
using foodDefense;
using System.Collections.Generic;

public class generateEnemyMinion : MonoBehaviour {

	public GameObject[] enemyMinions;
	[SerializeField] private int enemyDifficulty = 1;

	public Sprite[] sprites;
    public int pathIndex;

	private float startTime = 0f;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
		startTime += Time.deltaTime;
        if (startTime >= 9f) {
            GameObject enemy = (GameObject)Instantiate(enemyMinions[0], gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f));
            enemy.GetComponent<Enemy>().setPathIndex(pathIndex);

            int i = Random.Range(0, 7);
            if (i == 6)
            {
                enemy.GetComponent<Enemy>().thisType = food.Burger;
                enemy.GetComponent<Enemy>().mappingValue(food.Burger);
            }
            else {
                enemy.GetComponent<Enemy>().thisType = food.icecream;
                enemy.GetComponent<Enemy>().mappingValue(food.icecream);
            }

            enemy.GetComponent<SpriteRenderer> ().sprite = sprites [i];
			startTime = 0f;
		}
    }
}