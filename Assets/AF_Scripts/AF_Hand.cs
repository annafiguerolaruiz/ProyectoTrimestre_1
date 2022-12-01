using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AF_Hand : MonoBehaviour
{
    private Animator _animator;
    public bool IsCatch;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, -3.5f);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            _animator.SetBool("isCatch", true);
        } else
        {
            _animator.SetBool("isCatch", false);
        }


    }
}
