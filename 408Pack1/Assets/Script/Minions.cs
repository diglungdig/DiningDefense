using UnityEngine;
using System.Collections;
using foodDefense;
using UnityEngine.UI;

public abstract class Minions : MonoBehaviour {

    public int pathIndex = 0;
    public GameObject pathGO;

    public float health = 1f;
    public float dmg = 0f;

    public int moneyValue = 1;
    public food thisType;

    public Transform targetPathNode;
    public int pathNodeIndex = 0;
    public float speed = 1f;

    // Use this for initialization
    void Start()
    {
        pathGO = GameObject.Find("Path" + pathIndex.ToString());
        initilizePathNode();
    }
    public void setPathIndex(int index)
    {
        pathIndex = index;
        pathGO = GameObject.Find("Path" + pathIndex.ToString());
    }
    public void setMoneyValue(int amount)
    {
        moneyValue = amount;
    }
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
    public void mappingValue(food thisType)
    {
        if (thisType == food.banana)
        {
            this.dmg = 10f;
            this.health = 60f;
        }
        else if (thisType == food.apple)
        {
            this.dmg = 8f;
            this.health = 40f;
        }
        else if (thisType == food.strawberry)
        {
            this.dmg = 5f;
            this.health = 30f;
        }
    }
    public food returnFoodType()
    {
        return this.thisType;
    }

    public abstract void initilizePathNode();
    public abstract void GetNextPathNode();
    public abstract void ReachedGoal();

    // Update is called once per frame
    /*
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

    */

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // TODO: Do this more safely!
        GameObject.FindObjectOfType<ScoreManager2>().money += moneyValue;
        Destroy(gameObject);
    }
}
