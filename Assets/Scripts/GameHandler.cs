using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameHandler : MonoBehaviour
{
    public GameObject[] enemies;

    public int enemiesLeft;

    public int waveNumber;
    public UIManager ui;
    private int _spawnMultiplier = 2;

    // Start is called before the first frame update
    private void Start()
    {
        waveNumber = 1;
        ui.SetWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        ui.SetEnemiesCount(enemiesLeft);
        if (enemiesLeft == 0)
        {
            SpawnEnemies(5+_spawnMultiplier);
            if (waveNumber % 10 == 0)
            {
                _spawnMultiplier = 2;
            }
            else
            {
                _spawnMultiplier += 2;
            }
            waveNumber++;
            ui.SetWave(waveNumber);
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
