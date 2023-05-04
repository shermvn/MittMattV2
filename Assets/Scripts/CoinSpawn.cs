using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public float spawnDelay = 1.0f;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("spawn");
        // Instantiate the objectToInstantiate after a collision
        Invoke("SpawnObject", spawnDelay);

    }

    void SpawnObject()
    {
        Vector3 BlendForm = new Vector3(this.transform.position.x, this.transform.position.y+5, this.transform.position.z);
        Instantiate(objectToInstantiate, BlendForm, transform.rotation);
    }
}
