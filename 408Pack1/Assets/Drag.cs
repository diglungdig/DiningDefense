using UnityEngine;

public class Drag : MonoBehaviour
{
	public float dragSpeed = 0.75f;
	private Vector3 dragOrigin;


	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			dragOrigin = Input.mousePosition;
			return;
		}

		if (!Input.GetMouseButton(0)) return;
		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
		Debug.Log (pos.y);
		if ((Camera.main.transform.position.z >= 9 && pos.y < 0) || (Camera.main.transform.position.z <= -2.75 && pos.y > 0)
			|| (Camera.main.transform.position.z < 9 && Camera.main.transform.position.z > -2.75)) {
			Vector3 move = new Vector3 (0, 0, pos.y * dragSpeed);

			transform.Translate (move, Space.World);
		}
	}


}