using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 5f;
    private int amountOfTileOsScreen = 5;
    public float spX = 0;
    public float spY = 6;
    public float spZ = 1;
    // Use this for initialization
	void Start ()
	{
	    playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	    for (int i = 0; i < amountOfTileOsScreen; i++)
	    {
	        SpawnTile();
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    if (playerTransform.position.z > (spawnZ - amountOfTileOsScreen * tileLength))
	    {
	        SpawnTile();
	    }
	}

    private void SpawnTile(int PrefabIndex = -1)
    {
        
        GameObject go;
        go = Instantiate(tilePrefabs[0/*Convert.ToInt32(Random.Range(0,2))*/]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(spX, spY, spZ * spawnZ);
        spawnZ += tileLength;
    }
}
