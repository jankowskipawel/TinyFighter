using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthBar : MonoBehaviour
{
    private Transform _bar;
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSize(float sizeNormalized)
    {
        _bar = this.transform.Find("Bar");
        _bar.transform.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void SetColor(Color color)
    {
        _bar.transform.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
}
