using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostUp : MonoBehaviour
{
    private bool isColliding;
    public Rigidbody body;
    [SerializeField]protected float force;
    [SerializeField] float DelayBetweenForceShift;
    [SerializeField] bool willSwap;
    

    private void Start()
    {
        isColliding = false;

        if (willSwap == true)
        {
            InvokeRepeating(nameof(SwapForces), 0f, DelayBetweenForceShift);

        }
    }

    private void FixedUpdate()
    {
        Push();
    }

    private void Push()
    {
        if (isColliding == true)
        {
            body.AddForce(transform.up * force);
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StartPush(other);
    }

    private void StartPush(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopPush(other);
    }

    private void StopPush(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
        }
    }


    void SwapForces()
    {
      
        force *= -1;
    }
}
