using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("PPX", other.gameObject.transform.position.x);
            PlayerPrefs.SetFloat("PPY", other.gameObject.transform.position.y);
            PlayerPrefs.SetFloat("PPZ", other.gameObject.transform.position.z);
        }
    }
}
