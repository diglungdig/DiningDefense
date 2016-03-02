#pragma strict
  
 // Attach this script to an orthographic camera.
  
 private var object : Transform;     // The object we will move.
 private var offSet : Vector3;       // The object's position relative to the mouse position.
 private var dist   : float;
  
 function Update () {
  
     var ray = GetComponent.<Camera>().ScreenPointToRay(Input.mousePosition);     // Gets the mouse position in the form of a ray.
  
     if (Input.GetButtonDown("Fire1")) {     // If we click the mouse...
  
         if (!object) {      // And we are not currently moving an object...
  
             var hit : RaycastHit;
  
             if (Physics.Raycast(ray, hit, Mathf.Infinity) && (hit.collider.tag == "Draggable")) {        // Then see if an object is beneath us using raycasting.
  
                 object = hit.transform;     // If we hit an object then hold on to the object.
  
                 offSet = object.position-hit.point;        // This is so when you click on an object its center does not align with mouse position.
                 
                 dist = (ray.origin - hit.point).magnitude;  // Distance to the object from ray origin.
  
             }
  
         }
  
     }
  
     else if (Input.GetButtonUp("Fire1")) {
  
         object = null;      // Let go of the object.
  
     }
  
     if (object) {
  
         object.position = ray.GetPoint(dist) + offSet;    // Only move the object on a 2D plane.
  
     }
  
 }