using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AF_Menus : MonoBehaviour
{
    //Load scene menus
    public void SceneGame()
    {
        SceneManager.LoadScene("AF_GameA");
    }
    //Load scene options
    public void SceneOptions()
    {
        SceneManager.LoadScene("AF_Options");
    }
    //Load scene Scores
    public void SceneScores()
    {
        SceneManager.LoadScene("AF_Scores");
    }
    //Load scene Menu
    public void SceneMenu()
    {
        SceneManager.LoadScene("AF_MainMenu");
    }

}
