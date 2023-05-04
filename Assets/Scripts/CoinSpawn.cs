using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public static CoinSpawn Instance;
    public GameObject objectToInstantiate;
    public float spawnDelay = 1.0f;
    public int count = 0;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("spawn");
        // Instantiate the objectToInstantiate after a collision
        if (count == 0)
        {
            Invoke("SpawnObject", spawnDelay);
            count++;

        }

       
    }

    void SpawnObject()
    {
        Vector3 BlendForm = new Vector3(this.transform.position.x, this.transform.position.y+5, this.transform.position.z);
        Instantiate(objectToInstantiate, BlendForm, transform.rotation);
    }
}
