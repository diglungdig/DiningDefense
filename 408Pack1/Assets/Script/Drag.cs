using UnityEngine;

public class Drag : MonoBehaviour
{
	public float dragSpeed = 0.75f;
	private Vector3 dragOrigin;


    void Update()
    {
        if (Camera.main.transform.position.z > -20f)
        {

            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) return;
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);

            Debug.Log(pos.y);

           

            //Vector3 move = new Vector3 (0, 0, pos.y * dragSpeed);
            Vector3 move = new Vector3(0, pos.y * dragSpeed, 0);

            transform.Translate(move, Space.World);
           
        }

    }
}