using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace foodDefense
{

    public enum food
    {
        banana, strawberry, apple, Kale, Spinach, Burger, icecream
    }
		
    public class minion : MonoBehaviour
    {
        public food thisType;
		[SerializeField] private float health = 0f;
		[SerializeField] private float dmg = 0f;
		[SerializeField] private float healReductionDelta = 0f;
		[SerializeField] private float healthLoss = 0f;

		private bool isInCombat = false;
		private List<GameObject> enemys; 

		void Start(){
			enemys = new List<GameObject>(); 
		}

		public minion(food thisType){
			this.thisType = thisType;
			mappingValue (thisType);
			//should have a method to map the corresponding heal and dmg to each type
		}
		public void mappingValue(food thisType){
			if (thisType == food.banana) {
				this.dmg = 10f;
				this.health = 60f;
			} else if (thisType == food.apple) {
				this.dmg = 8f;
				this.health = 40f;
			} else if (thisType == food.strawberry) {
				this.dmg = 5f;
				this.health = 30f; 
			}
		}
			
		void OnTriggerEnter(Collider sth){
			Debug.Log ("I collide !!!!!!!");
			if ((sth.gameObject.tag == "enemyMinion" && thisType != food.icecream) || (sth.gameObject.tag == "allyMinion" && thisType == food.icecream)) {
				enemys.Add (sth.gameObject);
				startCombat (sth.gameObject.GetComponent<minion> ().dmg);
			}
			Debug.Log ("the color is" + GetComponent<SpriteRenderer> ().color);
		}


		public void startCombat(float dmgReductionPerSec){
			//switch material
			//start coroutine
			gameObject.GetComponent<AutoNav> ().stopAgent ();
			//change the color of the object when entering combat
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			healReductionDelta += dmgReductionPerSec;
			if (!isInCombat) {
				GetComponent<NavMeshAgent> ().speed = 0f;
				StartCoroutine (inCombat ());
			}
		}
		IEnumerator inCombat(){
			while (health > 0) {
				health -= healReductionDelta*0.05f;
				healthLoss += healReductionDelta * 0.05f;
				if (health <= 0){
					endCombat (true);
				}
				yield return null;
			}
				
		}
		public void endCombat(bool getDefeatedOrNot){
			if (!getDefeatedOrNot) {
				StopCoroutine (inCombat());
				gameObject.GetComponent<SpriteRenderer> ().color = new Color(1f,1f,1f,1f);
				gameObject.GetComponent<AutoNav> ().resumeAgent ();
				GetComponent<NavMeshAgent> ().speed = 2f;
				enemys.RemoveAt (enemys.Count-1);
			} else {
				if (enemys.Count != 0) {
					foreach (GameObject a in enemys) {
						if (a.GetComponent<minion> () != null) {
							a.GetComponent<minion> ().endCombat (false);
						}
					}
				}
				Destroy(gameObject);
			}
		}

		void OnTriggerExit(Collider sth){
			if ((sth.gameObject.tag == "enemyMinion" && thisType != food.icecream) || (sth.gameObject.tag == "allyMinion" && thisType == food.icecream)) {
				Debug.Log ("exit this fking shit");
				endCombat (false);
			}
		}
		//functions for external access
        public food returnFoodType()
        {
            return this.thisType;
        }


		void Update(){

			if (health <= 0) {
				endCombat (true);
			}
			if (GetComponentInChildren<Image> () != null) {
				GetComponentInChildren<Image> ().fillAmount = (health - healthLoss) / health;
			}
		}
    
	}
}