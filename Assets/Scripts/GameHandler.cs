using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameHandler : MonoBehaviour
{
    public GameObject[] enemies;

    private int enemiesCount;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemiesCount < 2)
        {
            SpawnEnemies(30);
        }
    }

    public void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)], GetPositionToSpawn(), Quaternion.identity);
        }
    }

    private Vector2 GetPositionToSpawn()
    {
        Vector2 result = new Vector3(33, 0, 0);
        var x = UnityEngine.Random.Range(0, 100);
        if (x <= 25)
        {
            result.x = 33;
            result.y = UnityEngine.Random.Range(-61, 0);
            return result;
        }

        if (x <= 50)
        {
            result.x = -28;
            result.y = UnityEngine.Random.Range(-61, 0);
            return result;
        }
        if (x <= 75)
        {
            result.x = UnityEngine.Random.Range(-28, 33);
            result.y = 0;
            return result;
        }
        if (x <= 100)
        {
            result.x = UnityEngine.Random.Range(-28, 33);
            result.y = -61;
            return result;
        }

        return result;
    }
}
