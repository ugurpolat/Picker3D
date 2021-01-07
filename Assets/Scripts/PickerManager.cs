using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickerManager : MonoBehaviour
{
    public static PickerManager instance;
    public Slider progressBar;
    void Awake()
    {
        instance = this;

    }
    public PickerState pickerState;
    public List<Collectible> collected = new List<Collectible>();
    public enum PickerState
    {
        Stop,
        Move
    }

    public void AddCollectible(Collectible collectible)
    {
        collected.Add(collectible);
    }
    public void RemoveCollectable(Collectible collectible)
    {
        collected.Remove(collectible);
    }

    public List<Collectible> GetCollectables()
    {
        return collected;
    }
    public void Clear()
    {
        collected.Clear();
    }
    public void DeleteCheckPoints()
    {
        PlayerPrefs.DeleteKey("PPX");
        PlayerPrefs.DeleteKey("PPY");
        PlayerPrefs.DeleteKey("PPZ");
    }
}
