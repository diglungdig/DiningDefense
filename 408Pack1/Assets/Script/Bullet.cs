using UnityEngine;
using System.Collections;


// Thanks to quill18.com for the advice on coding towers/bullets!

public class Bullet : MonoBehaviour {

	public float speed = 15f;
	public Transform target;
	public float damage = 0.5f;
	public float radius = 0;

    public GameObject explosionObject;
	// Update is called once per frame
	void Update () {
		if(target == null) {
			// Our enemy went away!
			Destroy(gameObject);
			return;
		}
		Vector3 dir = target.position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distThisFrame) {
			// We reached the node
			DoBulletHit();
		}
		else {
			// Move towards node
			transform.Translate( dir.normalized * distThisFrame, Space.World );
			Quaternion targetRotation = Quaternion.LookRotation( dir );
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
		}
	}

	void DoBulletHit() {
		if(radius == 0) {
			target.GetComponent<Enemy>().TakeDamage(damage);
		}
		else {
			Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);      
			foreach(Collider2D c in cols) {
				Enemy e = c.GetComponent<Enemy>();
				if(e != null) {
					e.GetComponent<Enemy>().TakeDamage(damage);
				}
			}
		}

        // TODO: Maybe spawn a cool "explosion" object here?
        if(radius != 0 && explosionObject!=null)
        {
            StartCoroutine(explosion());
        }
        else
            Destroy(gameObject);
	}

    IEnumerator explosion()
    {
        GameObject exp = (GameObject)Instantiate(explosionObject, transform.position, Quaternion.identity);
        //exp.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
