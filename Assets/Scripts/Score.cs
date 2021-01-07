using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

   
    [SerializeField]public Text reqText1;
    [SerializeField]public Text reqText2;
    

    public GameObject bottomPlatform;
    public int scoreTotal, score1, score2;
    public bool pass;

    // Start is called before the first frame update
    void Start()
    {
        scoreTotal = 0;
        score1 = Convert.ToInt32(reqText1.text);
        score2 = Convert.ToInt32(reqText2.text);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (score1 >= 0 && pass != true)
        {
            score1++;
            Destroy(other.gameObject, 1.5f);
            reqText1.text = score1.ToString();
            StartCoroutine(WaitAnimation());
            
        }
        
       
    }
    IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(2f);
        if (score1 >= score2)
        {
            bottomPlatform.GetComponent<Animator>().enabled = true;
            
            scoreTotal = score1;
            pass = true;
            PlayerPrefs.SetInt("Score1", scoreTotal);
            yield return new WaitForSeconds(1.5f);
            PickerManager.instance.pickerState = PickerManager.PickerState.Move;
            PickerManager.instance.progressBar.value = 1;

        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PickerManager.instance.DeleteCheckPoints();
        }
        
        
        

    }
}
