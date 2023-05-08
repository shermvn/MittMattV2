using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshGenerator : MonoBehaviour
{
    public GameObject mapContainer; // Container for map elements
    public NavMeshSurface navMeshSurface; // Reference to NavMeshSurface component

    List<NavMeshBuildSource> GetBuildSources()
    {
        // Collect the geometry representing walkable areas of your map
        // based on a specific layer and return as a list of NavMeshBuildSource objects.
        // You can add multiple sources if needed.

        int layerMask = 1 << LayerMask.NameToLayer("WhatIsGround"); // Replace "YourLayerName" with the desired layer name

        Collider[] colliders = mapContainer.GetComponentsInChildren<Collider>();
        List<NavMeshBuildSource> sources = new List<NavMeshBuildSource>();

        foreach (Collider collider in colliders)
        {
            if ((collider.gameObject.layer & layerMask) != 0)
            {
                NavMeshBuildSource source = new NavMeshBuildSource();
                source.shape = NavMeshBuildSourceShape.Mesh;
                source.transform = collider.transform.localToWorldMatrix;
                MeshFilter meshFilter = collider.GetComponent<MeshFilter>();
                source.size = meshFilter.mesh.bounds.size;
                source.sourceObject = meshFilter.sharedMesh;
                source.area = 0; // Default walkable area
                sources.Add(source);
            }
        }

        return sources;
    }

    void Start()
    {
        // Bake NavMesh
        NavMeshBuildSettings buildSettings = NavMesh.GetSettingsByID(0); // Assuming you're using the default NavMesh build settings
        NavMeshData navMeshData = NavMeshBuilder.BuildNavMeshData(buildSettings, GetBuildSources(), new Bounds(mapContainer.transform.position, mapContainer.transform.localScale), mapContainer.transform.position, mapContainer.transform.rotation);
        NavMesh.AddNavMeshData(navMeshData);

        // Assign NavMesh data to NavMeshSurface component
        navMeshSurface.navMeshData = navMeshData;
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class MeshGenerator : MonoBehaviour
//{
//    public GameObject mapContainer; // Container for map elements
//    public NavMeshSurface navMeshSurface; // Reference to NavMeshSurface component
//    public NavMeshAgent navMeshAgent; // Reference to NavMeshAgent component

//    NavMeshBuildSource[] GetBuildSources()
//    {
//        // Collect the geometry representing walkable areas of your map
//        // based on a specific layer and return as an array of NavMeshBuildSource objects.
//        // You can add multiple sources if needed.

//        int layerMask = 1 << LayerMask.NameToLayer("YourLayerName"); // Replace "YourLayerName" with the desired layer name

//        Collider[] colliders = mapContainer.GetComponentsInChildren<Collider>();
//        List<NavMeshBuildSource> sources = new List<NavMeshBuildSource>();

//        foreach (Collider collider in colliders)
//        {
//            if ((collider.gameObject.layer & layerMask) != 0)
//            {
//                NavMeshBuildSource source = new NavMeshBuildSource();
//                source.shape = NavMeshBuildSourceShape.Mesh;
//                source.transform = collider.transform.localToWorldMatrix;
//                MeshFilter meshFilter = collider.GetComponent<MeshFilter>();
//                source.size = meshFilter.mesh.bounds.size;
//                source.sourceObject = meshFilter.sharedMesh;
//                source.area = 0; // Default walkable area
//                sources.Add(source);
//            }
//        }

//        return sources.ToArray();
//    }

//    IEnumerator Start()
//    {
//        // Bake NavMesh
//        navMeshSurface.BuildNavMesh();

//        // Wait until NavMesh baking is complete
//        while (!navMeshSurface.isDone)
//        {
//            yield return null;
//        }

//        // NavMesh baking is complete, set destination for NavMeshAgent
//        navMeshAgent.SetDestination(/* Your destination position here */);
//    }
//}

