using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameObject picker;
    [SerializeField] private float camOffset;

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, picker.transform.position.z + camOffset);
    }

}
