using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRotation : MonoBehaviour
{
    public float rotationSpeed = 1f;

    void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;

        transform.Rotate(Vector3.forward, XaxisRotation);
    }
}
