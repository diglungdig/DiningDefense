using UnityEngine;
using System.Collections;

public class AutoNav : MonoBehaviour {

    //public Transform goal;
    private NavMeshAgent agent;
	public bool stopEnable = false;
	public enum agentType{
		allyMinion, enemyMinion
	}
	[SerializeField]
	private agentType thisType;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
		if (thisType == agentType.allyMinion) {
			agent.destination = GameObject.FindGameObjectWithTag ("destination").transform.position;
		} else {
			agent.destination = GameObject.FindGameObjectWithTag ("allyBase").transform.position;
		}
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

	public void stopAgent(){
		agent.Stop();
	}
	public void resumeAgent(){
		agent.Resume();
	}
}
