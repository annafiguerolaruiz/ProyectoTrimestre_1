using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AF_DataPersistents : MonoBehaviour
{
    public static AF_DataPersistents sharedInstance;
    public int LastRound;
    public string NamePlayer;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(sharedInstance);
        }
        else
        {
            Destroy(this);
        }
    }

    public void Data()
    {
        // We save the username with persistent data
        PlayerPrefs.SetString("NAME_PLAYER", NamePlayer);
        // We save the round number with persistent data
        PlayerPrefs.SetInt("LAST_ROUND", LastRound);
    }
}
