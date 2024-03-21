using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Launcher : MonoBehaviour
{
   
    private Move move;
    private Rigidbody rb;
    public Transform launchPoint;

    private void Awake()
    {
        move = FindAnyObjectByType<Move>();
        rb = FindAnyObjectByType<Rigidbody>();
        
    }
    private void OnMouseClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            
            move.enabled = true;
            rb.useGravity = true;
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

        // Convert the mouse position to world coordinates
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.y));

        Vector3 forwardDirection = mouseWorldPosition - new Vector3(transform.position.x, transform.position.y, mouseWorldPosition.z);
        transform.rotation = Quaternion.LookRotation(forwardDirection, Vector3.forward);
    }
}
