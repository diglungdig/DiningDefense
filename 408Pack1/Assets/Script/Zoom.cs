using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour
{

    float curZoomPos, zoomTo; // curZoomPos will be the value
    float zoomFrom = 19.5f; //Midway point between nearest and farthest zoom values (a "starting position")

    public Vector3 zoomOrigin = new Vector3(0f, 0f, -21f);


    void ZoomIn()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, 1000f), 1 / 3f);
    }

    void ZoomOut()
    {
        transform.position = Vector3.Lerp(transform.position, zoomOrigin, 1 / 3f);
    }

    void Update()
    {

       if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
           
            // Attaches the float y to scrollwheel up or down

            float y = Input.GetAxis("Mouse ScrollWheel");
            Debug.Log(y);

            // If the wheel goes up it, decrement 5 from "zoomTo"
            if (y > 0)
            {
                ZoomIn();
                Debug.Log("Zoomed In");
            }

            // If the wheel goes down, increment 5 to "zoomTo"
            else if (y < 0)
            {
                ZoomOut();
                Debug.Log("Zoomed Out");
            }
        }
    }
}