using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int gold;

    public Text GoldText;
    // Start is called before the first frame update
    void Start()
    {
        
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
    
}
