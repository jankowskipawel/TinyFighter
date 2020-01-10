using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSkillsUIScript : MonoBehaviour
{
    private ExpShowScript _expShowScript;
    // Start is called before the first frame update
    void Start()
    {
        _expShowScript = FindObjectOfType<ExpShowScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSkillsUI()
    {
        _expShowScript.OpenSkillsUI();
    }
}
