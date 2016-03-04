using UnityEngine;
using System.Collections;
using foodDefense;
using System;
using UnityEngine.UI;

public class Enemy : Minions {
    public override void initilizePathNode()
    {
        pathNodeIndex = 0;
    }
    public override void GetNextPathNode() {
		if(pathNodeIndex < pathGO.transform.childCount) {
			targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
			pathNodeIndex++;
		}
		else {
			targetPathNode = null;
			ReachedGoal();
		}
	}

    public override void ReachedGoal()
    {
        GameObject.Find("Health").GetComponent<Image>().fillAmount -= 1 / 12f;
        if (GameObject.Find("Health").GetComponent<Image>().fillAmount <= 0.1f)
        {
            GameObject.Find("EventSystem").GetComponent<sceneManage>().playerDeath();
        }
        Destroy(gameObject);
    }

   public override void OnTriggerEnter2D(Collider2D sth)
    {
        Debug.Log("enemy collides");
        if(sth.gameObject.tag == "allyMinion")
        {
            inCombat = true;
            GetComponent<Animator>().SetBool("inCombat", true);
            opponents.Add(sth.gameObject);
        }
    }

    public override void OnTriggerStay2D(Collider2D sth)
    {
        if (sth.gameObject.tag == "allyMinion")
        {
           TakeDamage(sth.GetComponent<Ally>().dmg);
        }
    }

    public override void OnTriggerExit2D(Collider2D sth)
    {
        if (sth.gameObject.tag == "allyMinion")
        {
            GetComponent<Animator>().SetBool("inCombat", false);
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
                // out of path
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
