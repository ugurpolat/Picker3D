using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Score score1;
    [SerializeField] Score2 score2;

    public int token;
    public static ScoreManager instance;
    public Text totalCoins;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        PlayerPrefs.SetInt("Token", 0);
    }
    public void GetCoins()
    {
        token = PlayerPrefs.GetInt("Score1") + PlayerPrefs.GetInt("Score2");
        PlayerPrefs.SetInt("Token", token);
        totalCoins.text = token.ToString();

    }
}
