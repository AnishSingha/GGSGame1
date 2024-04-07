using UnityEngine;
using System.Collections;


public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject; // The object to pool
    public Transform respawnPosition; // The position to respawn the object at
    public Launcher launcher;
    
    //public GameObject objectInstance; // The instance of the object in the scene

    void Start()
    {
        // Instantiate the object at the start
       // objectInstance = Instantiate(pooledObject, respawnPosition.position, Quaternion.identity);
    }

    void Update()
    {
        // If the object is not active, respawn it
        if (!pooledObject.activeInHierarchy)
        {
            
            launcher.enabled = true;
            pooledObject.transform.position = respawnPosition.position;
            pooledObject.SetActive(true);
        }
    }
}