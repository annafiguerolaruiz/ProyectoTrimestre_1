using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AF_Stickj : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Vector2 position;
    public float speed = 1;
    public float RangeY;
    public bool Catch;
    public GameObject Hand;
    public AF_GameManager GM;
    public bool GameOver;
    void Start()
    {
        speed = Random.Range(8, 20);

        RangeY = Random.Range(1, 3);
        transform.localScale = new Vector3(0.4f,RangeY);
        Catch = false;
        GameOver = false;
        
    }

     void Update()
    {
        Hand =  GameObject.FindGameObjectWithTag("Hand");

        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (Catch == true)
        {
            Hand.transform.position = new Vector2(position.x, Hand.transform.position.y);
        }
        if (transform.position.y <=-5)
        {
            
            GameOver = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        position.x = collision.gameObject.transform.position.x;

        if (collision.gameObject.CompareTag("Hand"))
        {
            speed = 0;
            Catch = true;
        }

    

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Catch = false;
        Destroy(gameObject);
    }
  

}
