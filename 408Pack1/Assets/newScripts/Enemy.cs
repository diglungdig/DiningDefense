using UnityEngine;
using System.Collections;
using foodDefense;

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
	
}
