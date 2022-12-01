using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AF_GameManager : MonoBehaviour
{
    public GameObject Stick;
    public int SticksLeft;
    private int SticksForWave = 1;
    public int Round;
    public TextMeshProUGUI RoundTEXT;
    public GameObject Pause;
    public GameObject Hand;


    void Start()
    {
        SpawnStickWave(1);
    }

     void Update()
    {
        RoundTEXT.text = Round.ToString();

        SticksLeft = FindObjectsOfType<AF_Stickj>().Length;

       if (SticksLeft <= 0)
        {
            Round++;
            SpawnStickWave(SticksForWave);
        }

       if (Round >= 30)
        {
            SceneManager.LoadScene("AF_Win");
        }
    }

     private void SpawnStick()
     {
        Instantiate(Stick, new Vector2(Random.Range(-6,6),6), transform.rotation);
     }


    private void SpawnStickWave(int totalSticks)
    {
        for (int i = 0; i < totalSticks; i++)
        {
            SpawnStick();
        }
    }

    public void GPause()
    {
        Pause.SetActive(true);
        Time.timeScale = 0f;
        Hand.SetActive(false);
    }

    public void GResume()
    {
        Time.timeScale = 1;
        Pause.SetActive(false); 
        Hand.SetActive(true);
    }

}
