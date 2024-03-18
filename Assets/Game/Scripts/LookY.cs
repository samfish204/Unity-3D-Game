using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
//    private float maxVerticalAngle = 90.0f;
    [SerializeField] float sensitivity = 0.95f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x -= mouseY * sensitivity;

        if (newRotation.x >= 90.0f || newRotation.x <= -90.0f) {
            //           newRotation.x = ClampVerticalAngle(newRotation.x);
            newRotation.y = 0;
            newRotation.z = 0;
//            newRotation.x = 90.0f;
        } // else if (newRotation.x <= -90.0f) {
//            newRotation.y = 0;
//            newRotation.z = 0;
//            newRotation.x = -90.0f;
//        }

        transform.localEulerAngles = newRotation;
    }

    private float ClampVerticalAngle(float angle)
    {
        if (angle >= 90.0f)
        {
            angle = 90.0f;
        } else if (angle <= -90.0f)
        {
            angle = -90.0f;
        }
        return angle;
    }
}
