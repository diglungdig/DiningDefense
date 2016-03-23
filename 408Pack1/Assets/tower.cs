using UnityEngine;
using System.Collections;

public class tower : MonoBehaviour {


// Thanks to quill18.com for the advice on coding towers/bullets!


	// Use this for initialization
	
	public float range = 10f;
	public GameObject bulletPrefab;

	public int cost = 5;

	float fireCooldown = 0.5f;
	float fireCooldownLeft = 0;

	public float damage = 1;
	public float radius = 0;
	
	
	void Start () {
	}
	
	void OnTriggerEnter(Collider sth){
		
		
		if (sth.gameObject.GetComponent<Minions>().thisType == foodDefense.food.icecream){
			Vector2 dir = sth.transform.position - this.transform.position;
			
			//shoot in that direction
			
			
			
		}
		
		
	}
	
	
	
	void OnTriggerExit(Collider sth){
		
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: Optimize this!
		Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

		Enemy nearestEnemy = null;
		float dist = Mathf.Infinity;

		foreach(Enemy e in enemies) {
			float d = Vector3.Distance(this.transform.position, e.transform.position);
			if(nearestEnemy == null || d < dist) {
				nearestEnemy = e;
				dist = d;
			}
		}

		if(nearestEnemy == null) {
			Debug.Log("No enemies?");
			return;
		}

        Vector3 dir = nearestEnemy.transform.position - this.transform.position;

        fireCooldownLeft -= Time.deltaTime;
		if(fireCooldownLeft <= 0 && dir.magnitude <= range) {
			fireCooldownLeft = fireCooldown;
			ShootAt(nearestEnemy);
		}
	}
		void ShootAt(Enemy e) {
		// TODO: Fire out the tip!
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);

		Bullet b = bulletGO.GetComponent<Bullet>();
		b.target = e.transform;
		b.damage = damage;
		b.radius = radius;
	}
}
