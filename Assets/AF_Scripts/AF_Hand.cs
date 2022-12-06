using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AF_Hand : MonoBehaviour
{
    private Animator _animator;
    public bool IsCatch;
    private AF_GameManager GameManagerScript;

    void Start()
    {
        _animator = GetComponent<Animator>();
        GameManagerScript = FindObjectOfType<AF_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerScript.startGame == true)
        {
            //With the mouse we will control the position of the hand
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, -3.5f);
            //If we left click we will activate the animation of the closed hand
            if (Input.GetKey(KeyCode.Mouse0))
            {
                _animator.SetBool("isCatch", true);
            }
            else
            {
                _animator.SetBool("isCatch", false);
            }

        }
    }
}
