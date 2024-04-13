using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum State
    {
        Idle,
        Jump,
        Push,
        JumpLoop,
        JumpEnd
    }

    public State state;
    public Animator animator; 

    void Update()
    {
        switch (state)
        {
            case State.Idle:
                HandleIdle();
                break;

            case State.Jump:
                HandleJump();
                break;

            case State.JumpLoop:
                HandleJumpLoop();
                break;

            case State.Push:
                HandlePush(); 
                break;

            case State.JumpEnd:
                HandleJumpEnd();
                break;
        }


        animator.SetInteger("state", (int)state);

        // Debugging
        if (Input.GetKeyDown(KeyCode.O)) state = State.Idle;
        if (Input.GetKeyDown(KeyCode.P)) state = State.Jump;
        if (Input.GetKeyDown(KeyCode.K)) state = State.JumpLoop;
        if (Input.GetKeyDown(KeyCode.L)) state = State.Push;
        if (Input.GetKeyDown(KeyCode.I)) state = State.JumpEnd;
    }

    void HandleIdle()
    {
        animator.Play("idle");
        //
    }

    void HandleJump()
    {
        animator.Play("jump");
        // Transition to JumpLoop state after some condition (e.g., peak of jump is reached)
    }

    void HandlePush()
    {
        animator.Play("push");
        // Transition to Idle state after some condition (e.g., push action is completed)
    }

    void HandleJumpLoop()
    {
        animator.Play("jump loop");
        // Transition to JumpEnd state after some condition (e.g., player starts falling)
    }

    void HandleJumpEnd()
    {
        animator.Play("jump end");
        // Transition to Idle state after some condition (e.g., player lands on the ground)
    }
}
