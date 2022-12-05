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
    public float Counter = 10;
    public TextMeshProUGUI TEXTtime;
    public bool startGame = false;

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
        Time.timeScale = 1;        
    }

     void Update()
     {
        if (Counter > 0)
        {
            UpdateTime();
        }
        //GO = FindObjectOfType<AF_Stickj>().GameOver;
        RoundTEXT.text = Round.ToString();

        SticksLeft = FindObjectsOfType<AF_Stickj>().Length;

       if (SticksLeft <= 0)
       {
            Round++;
            SpawnStickWave(SticksForWave);

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
        Time.timeScale = 0f;
        Pause.SetActive(true);
        Hand.SetActive(false);
    }

    public void GResume()
    {
        Time.timeScale = 1;
        Pause.SetActive(false); 
        Hand.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Palo"))
        {
            SceneManager.LoadScene("AF_GameOver");
            AF_DataPersistents.sharedInstance.LastRound = Round;
            AF_DataPersistents.sharedInstance.Data();
        }
    }
    public void UpdateTime()
    {
        Counter -= Time.deltaTime;
        //No milliseconds
        TEXTtime.text = Mathf.Round(Counter).ToString();
        if (Counter <=0)
        {
            TEXTtime.gameObject.SetActive(false);
            startGame = true;
        }
    }



}
