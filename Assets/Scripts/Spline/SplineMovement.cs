
using System;
using UnityEngine;
using UnityEngine.Splines;

public class SplineMovement : MonoBehaviour
{
    public SplineContainer splineContainer;
    public float speed = 2.0f;
    public bool loop = true;
    private int direction = 1;


    [Range(0, 1)]
    [SerializeField] public float t = 0.0f;

    [SerializeField] bool ResetMoves;
    [SerializeField] bool MovesBack;

    private void Update()
    {
        if (ResetMoves==true)
        {
            MoveWithSpline();
        }
        if (MovesBack==true) 
        {
            MoveBacknForthWithSpline();
        }
    }

    private void MoveBacknForthWithSpline()
    {

        if (splineContainer != null && splineContainer.Splines.Count > 0)
        {
            t += speed * Time.deltaTime * direction;

            if (t > 1.0f)
            {
                t = 1.0f;
                direction = -1; // Change direction to go backwards
            }
            else if (t < 0.0f)
            {
                t = 0.0f;
                direction = 1; // Change direction to go forwards
            }

            if (splineContainer.Evaluate(t, out var position, out var tangent, out _))
            {
                transform.SetPositionAndRotation(position, Quaternion.LookRotation(tangent, Vector3.up));
            }
        }

    }

    private void MoveWithSpline()
    {
        if (splineContainer != null && splineContainer.Splines.Count > 0)
        {
            t += speed * Time.deltaTime;

            if (t > 1.0f)
            {
                if (loop)
                {
                    t = 0.0f;
                }
                else
                {
                    t = 1.0f;
                }
            }

            if (splineContainer.Evaluate(t, out var position, out var tangent, out _))
            {

                transform.SetPositionAndRotation(position, Quaternion.LookRotation(tangent, Vector3.up));
            }
        }
    }
}
