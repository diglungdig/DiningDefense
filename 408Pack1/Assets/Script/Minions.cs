using UnityEngine;
using System.Collections;
using foodDefense;
using UnityEngine.UI;
using System.Collections.Generic;

public abstract class Minions : MonoBehaviour {

    public int pathIndex = 0;
    public GameObject pathGO;

    public float health = 1f;
    public float dmg = 0f;
    public int moneyValue = 0;
    public food thisType;

    public Transform targetPathNode;
    public int pathNodeIndex = 0;
    public float speed = 1f;
    public bool inCombat = false;

    public List<GameObject> opponents;

    private float originalHealth = 1f;

    // Use this for initialization
    void Start()
    {
        pathGO = GameObject.Find("Path" + pathIndex.ToString());
        initilizePathNode();
        opponents = new List<GameObject>();

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
            this.dmg = 1f;
            this.health = 60f;
            this.originalHealth = 60f;
        }
        else if (thisType == food.apple)
        {
            this.dmg = 4f;
            this.health = 200f;
            this.originalHealth = 200f;

        }
        else if (thisType == food.strawberry)
        {
            this.dmg = 1.5f;
            this.health = 30f;
            this.originalHealth = 30f;

        }
        else if(thisType == food.Burger)
        {
            this.dmg = 2f;
            this.health = 200f;
            this.moneyValue = 200;
            this.originalHealth = 200f;

        }
        else if(thisType == food.icecream)
        {
            this.dmg = 0.5f;
            this.health = 50f;
            this.originalHealth = 50f;
            this.moneyValue = 80;
        }
    }
    public food returnFoodType()
    {
        return this.thisType;
    }

    public abstract void initilizePathNode();
    public abstract void GetNextPathNode();
    public abstract void ReachedGoal();
    public abstract void OnTriggerEnter2D(Collider2D sth);
    public abstract void OnTriggerStay2D(Collider2D sth);
    public abstract void OnTriggerExit2D(Collider2D sth);

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        transform.GetComponentInChildren<Image>().fillAmount = health / originalHealth;
    }

    public void Die()
    {
        Debug.Log(gameObject.name);
        foreach(GameObject a in opponents)
        {
            a.GetComponent<Minions>().opponents.Remove(gameObject);
            if (a.GetComponent<Minions>().opponents.Count == 0)
            {
                a.GetComponent<Minions>().OnTriggerExit2D(gameObject.GetComponent<BoxCollider2D>());
            }
        }

        GameObject.Find("goldText").GetComponent<Text>().text = (int.Parse(GameObject.Find("goldText").GetComponent<Text>().text) + moneyValue).ToString();
        Destroy(gameObject);
    }
}
