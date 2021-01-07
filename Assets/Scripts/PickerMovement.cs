using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerMovement : MonoBehaviour
{
    [SerializeField] PickerManager pickerManager;
    

    [SerializeField] float movementSpeed;
    [SerializeField] float controlSpeed;

    [SerializeField] bool isTouching;
    float touchPosX;
    Vector3 direction;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("PPX"))
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("PPX"), PlayerPrefs.GetFloat("PPY"), PlayerPrefs.GetFloat("PPZ"));
        }
    }
    
    private void FixedUpdate()
    {
        if (pickerManager.pickerState == PickerManager.PickerState.Move)
        {
            transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
        }
        else if (pickerManager.pickerState == PickerManager.PickerState.Stop)
        {
            transform.position += Vector3.forward * 0 * Time.fixedDeltaTime;
            gameObject.GetComponent<PickerPhysic>().PushCollectibles();
        }
        if (isTouching)
        {
            touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
            if (touchPosX > 0.9f)
            {
                touchPosX = 0.9f;
            }
            else if (touchPosX < -0.9f)
            {
                touchPosX = -0.9f;
            }
            else
            {
                touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
            }
        }
       


        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
    }
    

    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
            
        }
        else
        {
            isTouching = false;
            
        }
    }

}
