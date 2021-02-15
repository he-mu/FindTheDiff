using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public float speed;

    private Touch touch;

    private Vector2 touchPosition;

    private Quaternion rotationY;
    private Quaternion rotationX;
    private Quaternion rotationZ;


    /*private void Update()
    {
        //touch = Input.GetMouseButton  Input.GetMouseButton(0);
        //touchPos = Input.mousePosition;

        // get touch
        if (Input.touchCount > 0)
        {
            // Get first touch input
            touch = Input.GetTouch(0);

            // if touch 1 is movign
            if ( touch.phase == TouchPhase.Moved )
            {
                rotationY = Quaternion.Euler(0f, -touch.deltaPosition.x * speed, 0f);

                // apply to current object
                transform.rotation = rotationY * transform.rotation;

            }
        }
    }*/



    // Static rotation
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }



    public void UpdateSpeed(float change)
    {
        speed = speed + change;
    }



    /*public void UpdateXRotation(float change)
    {

        transform.Rotate(Vector3.left, change);

        //transform.rotation = Quaternion.Euler(transform.rotation.x + change, transform.rotation.y, transform.rotation.z);


        //transform.rotation = Quaternion.Euler(X, Y, Z)

        //this.transform.rotation = this.transform.rotation + Quaternion.Euler(change, 0, 0)
    }*/

}
