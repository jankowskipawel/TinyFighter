using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExpShowScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text expText;

    public GameObject player;

    private float currentExp;

    private float maxExp;
    // Start is called before the first frame update
    void Start()
    {
        expText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        SetExpText(player.GetComponent<PlayerScript>().currentExp, player.GetComponent<PlayerScript>().maxExp);
        expText.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        expText.gameObject.SetActive(false);
    }
    
    public void SetExpText(float currentExp, float maxExp)
    {
        expText.text = $"{currentExp} / {maxExp}";
    }
}
