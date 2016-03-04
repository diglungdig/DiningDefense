using UnityEngine;
using System.Collections;
using System;

public class Ally : Minions {
    //public override int pathNodeIndex = 

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
