using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using foodDefense;
public class Ally : Minions {
    //public override int pathNodeIndex = 
	//public Text goldAmout;

	public int scoreValue;
	public GameObject gameController;

    public override void initilizePathNode()
    {
        pathNodeIndex = pathGO.transform.childCount - 1;
    }
    public override void GetNextPathNode()
    {
        if (pathNodeIndex >= 0)
        {
            targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
            pathNodeIndex--;
        }
        else {
            targetPathNode = null;
            ReachedGoal();
        }
    }
    public override void ReachedGoal()
    {
        Destroy(gameObject);
		GameObject.Find("goldText").GetComponent<Text>().text = (int.Parse(GameObject.Find("goldText").GetComponent<Text>().text) + moneyValue).ToString();
    }

    //collider and trigger functions overide
    public override void OnTriggerEnter2D(Collider2D sth)
    {
        Debug.Log("enemy collides");
        if (sth.gameObject.tag == "enemyMinion")
        {
            inCombat = true;
            opponents.Add(sth.gameObject);
        }
    }
    public override void OnTriggerStay2D(Collider2D sth)
    {
        Debug.Log("enemy stays");
        if (sth.gameObject.tag == "enemyMinion")
        {
            TakeDamage(sth.GetComponent<Enemy>().dmg);
        }
    }
    public override void OnTriggerExit2D(Collider2D sth)
    {
        if (sth.gameObject.tag == "enemyMinion")
        {
            inCombat = false;
        }
    }

    void Update()
    {
        if (pathGO == null)
            return;

        if (targetPathNode == null)
        {
            GetNextPathNode();
            if (targetPathNode == null)
            {
				GameObject.Find("GameController").GetComponent<GameController>().AddScore(1);

                // We've run out of path!
                ReachedGoal();

                return;
            }
        }

        Vector3 dir = targetPathNode.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            // We reached the node
            targetPathNode = null;
        }
        else if(!inCombat){
            // Move towards node
            transform.Translate(dir.normalized * distThisFrame, Space.World);
        }

    }
}
