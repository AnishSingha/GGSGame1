using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostUp : MonoBehaviour
{
    private bool _isColliding;
    private Rigidbody2D _body;

    [SerializeField]protected float force;
    [SerializeField] float DelayBetweenForceShift;
    [SerializeField] bool willSwap;
    [SerializeField] Animator animator;

    private void Awake()
    {
        _body = FindAnyObjectByType<Rigidbody2D>();
    }
    
    private void Start()
    {
        _isColliding = false;

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
        if (_isColliding == true)
        {
            _body.AddForce(transform.up * force);
            animator.SetTrigger("push");
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartPush(other);
    }

    private void StartPush(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isColliding = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        StopPush(other);
    }

    private void StopPush(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isColliding = false;
        }
    }


    void SwapForces()
    {
      
        force *= -1;
    }
}
