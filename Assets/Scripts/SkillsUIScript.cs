using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsUIScript : MonoBehaviour
{
    public Text SkillPointsText;

    private PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        SkillPointsText.text = $"Skillpoints: {playerScript.skillPoints}";
    }
}
