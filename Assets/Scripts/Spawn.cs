using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject boat;
    public GameObject[] spawn;
    public float spawnCd = 5;

    private float spawnTimer = 0;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnCd )
        {
            int random = Random.Range(0, 3);
            Instantiate(boat, spawn[random].transform.position, spawn[random].transform.rotation);
            spawnTimer = 0;
        }
    }
}
