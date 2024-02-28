using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacleprefab;
    private Vector3 spawnPos = new Vector3(30,0,0);
    private float startDelay = 1.0f;
    private float repeatDelay = 3.0f;
    public PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, 1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
       // repeatDelay = Random.Range(0.5f, 1.3f);
       if (playerControllerScript.gameOver == false)
       {
        Instantiate(obstacleprefab, spawnPos, obstacleprefab.transform.rotation);
       }
        
    }
}
