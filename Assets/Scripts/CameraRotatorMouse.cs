using UnityEngine;
using System.Collections;


public class CameraRotatorMouse : MonoBehaviour
{
    public float rotationSpeed;

    public GameObject TargetEmpty;


    void OnMouseDrag()
    {
        //Debug.Log("start drag");

        float rotX = Input.GetAxis("Mouse X") * rotationSpeed;
        float rotY = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.Rotate(Vector3.down, rotX);
        //transform.Rotate(Vector3.left, rotX);

        TargetEmpty.transform.Rotate(Vector3.down, rotX);
        //TargetEmpty.transform.Rotate(Vector3.left, rotX);

        

    }

}