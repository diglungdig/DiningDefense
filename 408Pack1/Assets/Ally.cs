using UnityEngine;
using System.Collections;

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
}
