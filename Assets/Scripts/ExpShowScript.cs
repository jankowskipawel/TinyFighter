using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExpShowScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text expText;
    public Text levelText;
    public Text skillPointText;
    public Image skillPointImage;
    public GameObject player;
    private PlayerScript playerScript;
    private float currentExp;
    private float maxExp;

    public GameObject SkillsUI;
    // Start is called before the first frame update
    void Start()
    {
        expText.gameObject.SetActive(false);
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        var tmpSkillpoints = playerScript.skillPoints;
        UpdateSkillPointAmount(tmpSkillpoints);
        if (tmpSkillpoints <= 0)
        {
            skillPointImage.color = Color.gray;
        }
        else
        {
            skillPointImage.color = new Color(1f, 0.298f, 0.298f);
        }

        if (Input.GetKeyDown("escape"))
        {
            CloseSkillsUI();
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        SetExpText(player.GetComponent<PlayerScript>().currentExp, player.GetComponent<PlayerScript>().maxExp);
        levelText.gameObject.SetActive(false);
        expText.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        expText.gameObject.SetActive(false);
        levelText.gameObject.SetActive(true);
    }
    
    public void SetExpText(float currentExp, float maxExp)
    {
        expText.text = $"{currentExp}\n/\n{maxExp}";
    }

    public void UpdateSkillPointAmount(int amount)
    {
        skillPointText.text = amount.ToString();
    }

    public void OpenSkillsUI()
    {
        SkillsUI.SetActive(true);
    }
    
    private void CloseSkillsUI()
    {
        SkillsUI.SetActive(false);
    }
}
