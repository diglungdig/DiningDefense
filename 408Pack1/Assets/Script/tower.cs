using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class tower : MonoBehaviour {


// Thanks to quill18.com for the advice on coding towers/bullets!


	// Use this for initialization
	
	public float range = 10f;
	public GameObject[] bulletPrefab;
	public int cost = 5;

	float fireCooldown = 0.2f;
	float fireCooldownLeft = 0;

	public float damage = 1;
	public float radius = 0;

    private int currentBulletVer = 0;
	

    public void UpdateTurret()
    {
        //upgrade turret, increase the index to switch bullet
        currentBulletVer++;
        if(currentBulletVer == 1)
        {
            //upgrade #1
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if(currentBulletVer == 2)
        {
            //ultimate upgrade
            GetComponent<SpriteRenderer>().color = Color.black;
            transform.localScale = transform.localScale * 2;
            //set crown icon active
            transform.GetChild(1).gameObject.SetActive(true);
            //disable upgrade button
            GetComponentInChildren<Canvas>().enabled = false;
        }
    }

	void OnTriggerEnter(Collider sth){
		if (sth.gameObject.GetComponent<Minions>().thisType == foodDefense.food.icecream){
			Vector2 dir = sth.transform.position - this.transform.position;
		}
	}

	// Update is called once per frame
	void Update () {
		// TODO: Optimize this!
		Minions[] enemies = GameObject.FindObjectsOfType<Enemy>() ;
		Minions[] allies = GameObject.FindObjectsOfType<Ally> ();

		Enemy nearestEnemy = null;
		Ally nearestAlly = null;
		float dist = Mathf.Infinity;
		float dist2 = Mathf.Infinity;

		foreach(Enemy e in enemies) {
			float d = Vector3.Distance(this.transform.position, e.transform.position);
			if(nearestEnemy == null || d < dist) {
				nearestEnemy = e;
				dist = d;
			}
		}
		foreach(Ally e in allies) {
			float d = Vector3.Distance(this.transform.position, e.transform.position);
			if(nearestAlly == null || d < dist2) {
				nearestAlly = e;
				dist2 = d;
			}
		}

		if (nearestEnemy == null && nearestAlly == null) {
			return;
		}

		if (nearestEnemy != null) {
			Vector3 dir = nearestEnemy.transform.position - this.transform.position;

			fireCooldownLeft -= Time.deltaTime;
			if(fireCooldownLeft <= 0 && dir.magnitude <= range) {
				fireCooldownLeft = fireCooldown;
				ShootAt(nearestEnemy);
			}
		}
			
		if (nearestAlly != null) {
			Vector3 dir2 = nearestAlly.transform.position - this.transform.position;
			fireCooldownLeft -= Time.deltaTime;
			if (fireCooldownLeft <= 0 && dir2.magnitude <= range) {
				fireCooldownLeft = fireCooldown;
				ShootAt (nearestAlly);
			}
		}
	}
	void ShootAt(Enemy e) {
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab[currentBulletVer], this.transform.position, this.transform.rotation);

		Bullet b = bulletGO.GetComponent<Bullet>();
		b.target = e.transform;
	}
	void ShootAt(Ally e) {
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab[currentBulletVer], this.transform.position, this.transform.rotation);

		Bullet b = bulletGO.GetComponent<Bullet>();
		b.target = e.transform;
	}
}
