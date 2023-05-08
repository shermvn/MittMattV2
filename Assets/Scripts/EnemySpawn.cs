using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabToSpawn;
    // Update is called once per frame

    void Start()
    {
        SpawnObject();
    }
    private void SpawnObject()
    {
        // Instantiate the prefab at the current position of the Spawner
        //Vector3 lift = new Vector3(transform.position.x, transform.position.y + 5, transform.position.y);
        //GameObject spawnedObject = Instantiate(prefabToSpawn, lift, Quaternion.identity);
        GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

        // You can also modify properties of the spawned object if needed
        // spawnedObject.transform.localScale = Vector3.one * 2f;
    }

}
