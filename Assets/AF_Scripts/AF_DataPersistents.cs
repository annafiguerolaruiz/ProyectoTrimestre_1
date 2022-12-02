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
        PlayerPrefs.SetString("NAME_PLAYER", NamePlayer);
        PlayerPrefs.SetInt("LAST_ROUND", LastRound);
    }
}
