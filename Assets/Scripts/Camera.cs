using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform ObjectTransform;
    public Transform CameraTransform;

    // Update is called once per frame
    void Update()
    {
        if (ObjectTransform)
        {
            CameraTransform.rotation = ObjectTransform.rotation;
            CameraTransform.position = ObjectTransform.position;// - Vector3.forward;
        }
    }
}
