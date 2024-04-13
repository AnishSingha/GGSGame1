using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using UnityEngine;

public class CloudSaveInitialization : MonoBehaviour
{
    public async void Start()
    {
        await UnityServices.InitializeAsync();
    }

}
