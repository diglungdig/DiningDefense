using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class minion : MonoBehaviour {
	
	
	
	
	void OnTriggerEnter(Collider sth){
		if (sth.gameObject.tag == "enemyMinion"){
			
		}
	}
	
	
	void OnTriggerExit(Collider sth){
		
	}
	
}