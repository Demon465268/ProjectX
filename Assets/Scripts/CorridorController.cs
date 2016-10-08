using System;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class CorridorController : MonoBehaviour {

    private float spawnZ = 0.0f;
    private float tileLength = 5f;
    private int amountOfTileOnScreen = 20;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void Update()
    {
        if ((playerTransform.position.z - gameObject.transform.position.z) > tileLength*amountOfTileOnScreen/2)
        {
            Destroy(this.gameObject);
        }
    }
}
