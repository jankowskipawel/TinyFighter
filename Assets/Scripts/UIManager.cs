using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float gold;
    public GameObject player;
    public Text GoldText;
    public Text WaveText;
    public Text EnemyText;
    private GameHandler gameHandler;
    public Text TimerText;

    private bool isTowerUIOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameHandler = FindObjectOfType<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        var tmpTimer = gameHandler.GetTimer();
        if (tmpTimer >= 0)
        {
            TimerText.text = Math.Round(tmpTimer).ToString();
        }
        if (tmpTimer == 5)
        {
            TimerText.text = "";
        }

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

    public void RefreshGoldAmount()
    {
        GoldText.text = "Gold: " + gold;
    }
    
    public bool GetIsTowerUIOpened()
    {
        return isTowerUIOpened;
    }
    
    public void SetTowerUI(bool x)
    {
        isTowerUIOpened = x;
    }
}
