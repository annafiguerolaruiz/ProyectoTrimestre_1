using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AF_Menus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneGame()
    {
        SceneManager.LoadScene("AF_GameA");
    }
     
    public void SceneOptions()
    {
        SceneManager.LoadScene("AF_Options");
    }
    public void SceneScores()
    {
        SceneManager.LoadScene("AF_Scores");
    }
    public void SceneMenu()
    {
        SceneManager.LoadScene("AF_MainMenu");
    }

}
