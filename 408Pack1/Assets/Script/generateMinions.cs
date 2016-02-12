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
			//banana
			GameObject newObject = (GameObject)Instantiate(minion1, genePos, Quaternion.Euler(90f, 180f, 180f));
			newObject.AddComponent<minion> ().thisType = food.banana;
			newObject.GetComponent<minion> ().mappingValue(food.banana);  
			costMoney(costList(newObject.GetComponent<minion>().returnFoodType()));
        }
        else if (index == 2)
        {
			//strawberry
			GameObject newObject = (GameObject)Instantiate(minion2, genePos, Quaternion.Euler(90f, 180f, 180f));
			newObject.AddComponent<minion> ().thisType = food.strawberry;
			newObject.GetComponent<minion> ().mappingValue (food.strawberry);
			costMoney(costList(newObject.GetComponent<minion>().returnFoodType()));
			//gameObject.GetComponent<Button>()
		}
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void costMoney(int amount)
    {
        goldAmout.text = (int.Parse(goldAmout.text) - amount).ToString();
		GetComponent<AudioSource> ().Play ();
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
