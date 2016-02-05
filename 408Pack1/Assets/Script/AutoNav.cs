using UnityEngine;
using System.Collections;

public class AutoNav : MonoBehaviour {

    //public Transform goal;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = GameObject.FindGameObjectWithTag("destination").transform.position;
        agent.updateRotation = false;
    }

    void Update()
    {
        if (!agent.pathPending)
        {
            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                if(!agent.hasPath || agent.pathStatus == NavMeshPathStatus.PathComplete)
                {
                    Destroy(gameObject);
                }
            }

        }

    }
}
