using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float MoveSpeedRight;
    

    private void Update()
    {
        MoveRight();
    }
  
    private void MoveRight()
    {       
        transform.Translate(MoveSpeedRight * Time.deltaTime * Vector3.right);       
    }

}
