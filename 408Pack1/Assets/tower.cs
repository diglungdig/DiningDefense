using UnityEngine;
using System.Collections;

public class tower : MonoBehaviour {

	// Use this for initialization
	
	
	
	
	void Start () {
	}
	
	
	
	void OnTriggerEnter(Collider sth){
		
		
		if (sth.gameObject.thisType == "icecream"){
			Vector2 dir = sth.transform.position - this.transform.position;
			
			//shoot in that direction
			
			
			
		}
		
		
	}
	
	
	
	void OnTriggerExit(Collider sth){
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
