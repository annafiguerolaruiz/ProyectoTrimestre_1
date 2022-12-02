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
    public static AF_GameManager sharedInstance;
    public bool GO;
    public TextMeshProUGUI time;
    public float timeValue;
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
        SpawnStickWave(1);
        Round = 1;

    }

     void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        //DisplayTime(timeValue);
        GO = FindObjectOfType<AF_Stickj>().GameOver;
        RoundTEXT.text = Round.ToString();

        SticksLeft = FindObjectsOfType<AF_Stickj>().Length;

       if (SticksLeft <= 0)
        {
            if (timeValue <=0)
            {
                Round++;
                SpawnStickWave(SticksForWave);
            }
           
        }

       if (Round >= 30)
        {
            SceneManager.LoadScene("AF_Wine");
            AF_DataPersistents.sharedInstance.LastRound = Round;
        }
       if (GO == true)
        {
            SceneManager.LoadScene("AF_GameOver");
            AF_DataPersistents.sharedInstance.LastRound = Round;
            AF_DataPersistents.sharedInstance.Data();
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
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
