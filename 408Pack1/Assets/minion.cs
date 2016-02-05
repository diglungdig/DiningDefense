using UnityEngine;
using System.Collections;

namespace foodDefense
{

    public enum food
    {
        banana, strawberry, apple
    }

    public class minion : MonoBehaviour
    {

        public food thisType;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public food returnFoodType()
        {
            return this.thisType;
        }
    }
}