using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorChangeScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject cursor;

    public Sprite cursorOverUI;

    private Sprite oldCursor;

    private bool isOverUI = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOverUI = true;
        oldCursor = cursor.GetComponent<SpriteRenderer>().sprite;
        cursor.GetComponent<SpriteRenderer>().sprite = cursorOverUI;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOverUI = false;
        cursor.GetComponent<SpriteRenderer>().sprite = oldCursor;
    }

    public bool GetIsOverUI()
    {
        return isOverUI;
    }
}
