using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Launcher : MonoBehaviour
{
   
    private Move move;
    private Rigidbody2D rb;
    [SerializeField] Animator animator;

    public GameObject platform;

    private void Awake()
    {
        move = FindAnyObjectByType<Move>();
        rb = FindAnyObjectByType<Rigidbody2D>();
        
    }

    private void OnMouseClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetTrigger("JumpStart");
            StartCoroutine(DelayBeforeJump());

            platform.transform.parent = null;

        }   
    }

    private IEnumerator DelayBeforeJump()
    {
        yield return new WaitForSeconds(0.5f);
        move.enabled = true;
        rb.gravityScale = 1;
        this.enabled = false;
    }

    void Update()
    {

        OnMouseClick();
        LookAtMousePosition();
    }

    public void LookAtMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;
    }
}
