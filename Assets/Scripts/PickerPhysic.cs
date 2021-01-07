using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickerPhysic : MonoBehaviour
{
    [SerializeField] PickerManager pickerManager;
    private Rigidbody rb;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        pickerManager.pickerState = PickerManager.PickerState.Move;
    }
    public void Stop()
    {
        pickerManager.pickerState = PickerManager.PickerState.Stop;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        var collectible = other.GetComponent<Collectible>();
        if (collectible != null)
        {
            pickerManager.AddCollectible(collectible);
            
        }
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            Stop();
            
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("EndPoint"))
        {
            Stop();
            
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("NextLevel"))
        {
            panel.SetActive(true);
            this.gameObject.SetActive(false);
            ScoreManager.instance.GetCoins();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        var collectible = other.GetComponent<Collectible>();
        if (collectible != null)
        {
            pickerManager.RemoveCollectable(collectible);
        }
    }
    
    public void PushCollectibles()
    {
        foreach (var collectible in pickerManager.GetCollectables())
        {
            collectible.Push();
            //Destroy(collectible.gameObject, 2f);
        }
    }
}
