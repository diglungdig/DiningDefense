﻿using UnityEngine;
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
        else {
            // TODO: Consider ways to smooth this motion.

            // Move towards node
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            //Quaternion targetRotation = Quaternion.LookRotation( dir );
            //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
        }

    }
}
