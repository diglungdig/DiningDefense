using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using foodDefense;

public class generateMinions : MonoBehaviour {

    public Vector3 genePos;
    public GameObject minion1;
    public GameObject minion2;
    public Text goldAmout;

    public void GenerateOne(int index)
    {
        if (index == 1)
        {
            Instantiate(minion1, genePos, Quaternion.Euler(90f, 180f, 180f));
            costMoney(costList(minion1.GetComponent<minion>().returnFoodType()));
        }
        else if (index == 2)
        {
            Instantiate(minion2, genePos, Quaternion.Euler(90f, 180f, 180f));
            costMoney(costList(minion1.GetComponent<minion>().returnFoodType()));
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void costMoney(int amount)
    {
        goldAmout.text = (int.Parse(goldAmout.text) - amount).ToString();

    }
    
    private int costList(food foodType)
    {
        if (foodType == food.banana)
            return 50;
        else if (foodType == food.strawberry)
            return 100;
        return 0;
    }

}
