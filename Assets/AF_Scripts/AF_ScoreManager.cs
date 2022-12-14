using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AF_ScoreManager : MonoBehaviour
{
    public static AF_ScoreManager sharedInstance;

    public TextMeshProUGUI Round;
    public TextMeshProUGUI username;
    public int R;
    public string N;


    void Start()
    {
        ApplyUserOptions();
    }
    void Update()
    {
        SaveUserOptions();
    }
    //We load the persistence of data on the screen, the username and the number of rounds reached in the game
    public void ApplyUserOptions()
    {
        R = PlayerPrefs.GetInt("LAST_ROUND");
        Round.text = R.ToString();
        N = PlayerPrefs.GetString("NAME_PLAYER");
        username.text = N.ToString();

    }
    // We save the persistence of data again
    public void SaveUserOptions()
    {
        AF_DataPersistents.sharedInstance.LastRound = R;
        AF_DataPersistents.sharedInstance.NamePlayer = N;
        AF_DataPersistents.sharedInstance.Data();

    }
}