﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int gold;
    public GameObject player;
    public Text GoldText;
    public Text WaveText;
    public Text EnemyText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGold(int goldToAdd)
    {
        this.gold += goldToAdd;
        GoldText.text = "Gold: " + gold;
    }
    
    public void SetWave(int waveNumber)
    {
        WaveText.text = "Wave: " + waveNumber;
    }
    
    public void SetEnemiesCount(int enemiesCount)
    {
        EnemyText.text = "Enemies left: " + enemiesCount;
    }
}
