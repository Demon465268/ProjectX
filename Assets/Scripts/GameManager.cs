using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using Random = System.Random;

public class GameManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 12f;
    private int amountOfTileOnScreen = 10;
    public float spX = 0;
    public float spY = 6;
    public float spZ = 1;
    Random rnd = new Random();
    private int rnd_index;

    void Start ()
	{
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	    for (int i = 0; i < amountOfTileOnScreen; i++)
	    {
	        SpawnTile();
	    }
	}
	
	void Update () {
	    if (playerTransform.position.z > (spawnZ - amountOfTileOnScreen * tileLength))
	    {
	        SpawnTile();
	    }
	}
    
    private void SpawnTile(int PrefabIndex = -1)
    {
        GameObject go;
        rnd_index = rnd.Next(0, 3);
        go = Instantiate(tilePrefabs[rnd_index]);
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(spX, spY, spZ * spawnZ);
        spawnZ += tileLength;
        
    }
}
