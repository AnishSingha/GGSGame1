using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Launcher : MonoBehaviour
{
   
    private Move move;
    private Rigidbody2D rb;
    public Transform launchPoint;

    private void Awake()
    {
        move = FindAnyObjectByType<Move>();
        rb = FindAnyObjectByType<Rigidbody2D>();
        
    }
    private void OnMouseClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            
            move.enabled = true;
            rb.gravityScale = 1;
            this.enabled = false;
            

        }   
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
