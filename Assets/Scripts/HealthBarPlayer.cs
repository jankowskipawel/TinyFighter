using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPlayer : MonoBehaviour
{
    
    private HealthBar _bar;
    private PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        //_bar = player.GetComponent<PlayerScript>().healthBar;
    }

    // Update is called once per frame
    void Update()
    {
        float healthPrecentage = player.currentHP / player.maxHP;
        if (healthPrecentage <= 0.9f)
        {
            _bar.SetColor(new Color(0.647f, 1f, 0f, 1));
        }
        if (healthPrecentage <= 0.5f)
        {
            _bar.SetColor(new Color(1f, 1f, 0f, 1));
        }
        if (healthPrecentage <= 0.3f)
        {
            _bar.SetColor(new Color(1f, 0f, 0f, 1));
        }
        if (healthPrecentage <= 0.15f)
        {
            _bar.SetColor(new Color(0.75f, 0f, 0f, 1));
        }

        if (healthPrecentage > 0.9f)
        {
            _bar.SetColor(new Color(0f, 1f, 0f, 1));
        }
        
    }
    
    public void SetSize(float sizeNormalized)
    {
        Transform tBar = _bar.transform.Find("Bar");
        tBar.transform.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void SetColor(Color color)
    {
        _bar.transform.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
}
