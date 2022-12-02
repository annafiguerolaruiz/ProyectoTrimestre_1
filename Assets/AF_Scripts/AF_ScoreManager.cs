using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AF_ScoreManager : MonoBehaviour
{
    public static AF_ScoreManager sharedInstance;

    public TextMeshProUGUI Round;
    public TextMeshProUGUI username;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        ApplyUserOptions();
    }

    public void ApplyUserOptions()
    {
        Round.text = AF_DataPersistents.sharedInstance.LastRound.ToString();
        username.text = AF_DataPersistents.sharedInstance.NamePlayer;
    }
}
