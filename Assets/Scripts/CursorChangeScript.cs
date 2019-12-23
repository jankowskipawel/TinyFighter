using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorChangeScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private SpriteRenderer cursor;

    public Sprite cursorOverUI;

    private Sprite oldCursor;

    public PointAndShoot pointAndShoot;
    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.Find("Crosshair").GetComponent<SpriteRenderer>();
        oldCursor = cursor.sprite;
        pointAndShoot = GameObject.Find("Main Camera").GetComponent<PointAndShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointAndShoot.SetIsOverUI(true);
        cursor.sprite = cursorOverUI;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointAndShoot.SetIsOverUI(false);
        cursor.sprite = oldCursor;
    }

    private void OnDisable()
    {
        pointAndShoot.SetIsOverUI(false);
    }
}
