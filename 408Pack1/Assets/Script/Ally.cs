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
        throw new NotImplementedException();
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
