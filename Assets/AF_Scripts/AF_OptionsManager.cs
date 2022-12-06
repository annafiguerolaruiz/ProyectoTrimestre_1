using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AF_OptionsManager : MonoBehaviour
{
    public TMP_InputField Name;
    // Start is called before the first frame update
    void Start()
    {
        LoadUserOptions();
    }
    //Load the data persistence of the username text
    public void SaveUserOptions()
    {
        AF_DataPersistents.sharedInstance.NamePlayer = Name.text;

        AF_DataPersistents.sharedInstance.Data();
    }
    public void LoadUserOptions()
    {

        Name.text = PlayerPrefs.GetString("NAME_PLAYER");
    }
}
