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
        //Counter
        if (Counter > 0)
        {
            UpdateTime();
        }
        //GO = FindObjectOfType<AF_Stickj>().GameOver;
        RoundTEXT.text = Round.ToString();

        SticksLeft = FindObjectsOfType<AF_Stickj>().Length;
        //Every time a suit is eliminated or there is no suit in the scene, a new suit will be instantiated
        if (SticksLeft <= 0)
       {
            Round++;
            SpawnStickWave(SticksForWave);

       }

       if (Round >= 30)
       {
            //When you reach the maximum number of rounds(30), the Win screen will appear.
           SceneManager.LoadScene("AF_Wine");
            AF_DataPersistents.sharedInstance.LastRound = Round;
       }
       if (GO == true)
       {
            //When you do not grab one of the sticks the Lose screen will appear
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
    //When we press the pause button we will stop time and the pause menu will appear
    public void GPause()
    {
        Time.timeScale = 0f;
        Pause.SetActive(true);
        Hand.SetActive(false);
    }
    //When we press the game button, we will restart the game from where we left it before pausing
    public void GResume()
    {
        Time.timeScale = 1;
        Pause.SetActive(false); 
        Hand.SetActive(true);
    }
    //When a stick collides with the colider, the Game Over will appear
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Palo"))
        {
            SceneManager.LoadScene("AF_GameOver");
            AF_DataPersistents.sharedInstance.LastRound = Round;
            AF_DataPersistents.sharedInstance.Data();
        }
    }
    // When the game starts, a counter will appear to indicate when the game will start
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
