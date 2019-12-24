using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public TowerScript towerScript;

    public UIManager UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("CanvasUI").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddRange()
    {
        if (UI.gold >= towerScript.GetUpgradeCost() && !towerScript.IsMaxRange())
        {
            UI.gold -= towerScript.GetUpgradeCost();
            towerScript.IncreaseRange();
            UI.RefreshGoldAmount();
        }
    }
    
}
