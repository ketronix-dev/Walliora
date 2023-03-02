using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public bool isRed;
    [HideInInspector] public bool isGreen;
    
    
    [Header("Walls:")]
    [SerializeField] private GameObject[] RedWalls;
    [SerializeField] private GameObject[] GreenWalls;

    [Header("Spawn Settings:")]
    [SerializeField] private Transform playerSpawn;
    [SerializeField] private GameObject playerPrefab;


    private void Start()
    {
        var player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Destroy(player);
        }

        Instantiate(playerPrefab, playerSpawn.position, Quaternion.LookRotation(playerSpawn.forward));
    }

    void Update()
    {
        if (isRed && isGreen == false)
        {
            foreach (var wall in RedWalls)
            {
                wall.GetComponent<Collider>().isTrigger = false;
            }
            
            foreach (var wall in GreenWalls)
            {
                wall.GetComponent<Collider>().isTrigger = true;
            }
        }
        else if(isRed == false && isGreen)
        {
            foreach (var wall in RedWalls)
            {
                wall.GetComponent<Collider>().isTrigger = true;
            }
            
            foreach (var wall in GreenWalls)
            {
                wall.GetComponent<Collider>().isTrigger = false;
            }
        }
        
    }
}
