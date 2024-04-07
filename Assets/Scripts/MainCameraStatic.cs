using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCameraStatic : MonoBehaviour
{
    public static MainCameraStatic Instance;
    private void Awake()
    {
        InstanceCreation();
    }


    private void InstanceCreation()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
