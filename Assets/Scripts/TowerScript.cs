﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour
{
    public GameObject attackPrefab;

    public float spellSpeed;

    public float attackRate;

    private float timer = 0;

    private GameObject[] enemiesInRange;

    public float towerRange;

    public GameObject rangeCircle;

    public Animator animator;

    private static readonly int Attack1 = Animator.StringToHash("attack");

    public GameObject TowerUI;
    private SpriteRenderer cursorCrosshair;
    private Sprite cursorSprite;
    private float upgradeCost = 100;
    private bool isMaxRange = false;
    public Text upgradeCostText;
    private float bonusDamage = 0;
    private TowerUIScript TUIScript;
    private bool isUIActive = false;
    private float upgradesWorth;
    public float towerPrice;
    private UIManager UI;

    // Start is called before the first frame update
    void Start()
    {
        cursorCrosshair = GameObject.Find("Crosshair").GetComponent<SpriteRenderer>();
        cursorSprite = cursorCrosshair.sprite;
        TowerUI.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        upgradeCostText.text = upgradeCost.ToString();
        TUIScript = TowerUI.GetComponent<TowerUIScript>();
        TUIScript.UpdateText();
        UI = GameObject.Find("CanvasUI").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackRate)
        {
            enemiesInRange = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemiesInRange.Length > 0)
            {
                foreach (var enemy in enemiesInRange)
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) < towerRange)
                    {
                        Attack(enemy.transform.position);
                        animator.SetTrigger(Attack1);
                        break;
                    }
                }
            }
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TowerUI.SetActive(false);
            rangeCircle.SetActive(false);
            isUIActive = false;
            UI.SetTowerUI(false);
            cursorCrosshair.sprite = cursorSprite;
        }
    }

    public void Attack(Vector3 targetPos)
    {
        GameObject b = Instantiate(attackPrefab) as GameObject;
        b.GetComponent<SpellScript>().damage += bonusDamage;
        var position = transform.position;
        position.y += 1;
        Vector3 difference = targetPos - position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        b.transform.position = position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ+90);
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        b.GetComponent<Rigidbody2D>().velocity = direction * spellSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
    }

    private void OnMouseEnter()
    {
        rangeCircle.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (!isUIActive)
        {
            rangeCircle.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (!UI.GetIsTowerUIOpened())
        {
            TowerUI.SetActive(true);
            rangeCircle.SetActive(true);
            isUIActive = true;
            UI.SetTowerUI(true);
        }
    }

    public void IncreaseRange()
    {
        if (towerRange < 61.38)
        {
            if (towerRange + 0.1f > 61.38)
            {
                towerRange = 61.38f;
                isMaxRange = true;
            }
            else
            {
                towerRange += 0.1f;
            }
            rangeCircle.transform.localScale += new Vector3(0.018f, 0.018f, 0.018f);
            IncreaseCostAndRefresh();
        }
    }

    public void IncreaseDamage()
    {
        bonusDamage += 5;
        IncreaseCostAndRefresh();
    }

    public void IncreaseCostAndRefresh()
    {
        IncreaseUpgradesWorth(upgradeCost);
        upgradeCost += 50;
        upgradeCostText.text = upgradeCost.ToString();
        TUIScript.UpdateText();
    }

    public void IncreaseAttackSpeed()
    {
        attackRate -= 0.01f;
        IncreaseCostAndRefresh();
    }

    public float GetUpgradeCost()
    {
        return upgradeCost;
    }

    public bool IsMaxRange()
    {
        return isMaxRange;
    }

    public float GetDamage()
    {
        return bonusDamage + attackPrefab.GetComponent<SpellScript>().damage;
    }

    public float GetTowerWorth()
    {
        return towerPrice + upgradesWorth;
    }

    private void IncreaseUpgradesWorth(float amount)
    {
        upgradesWorth += amount;
    }
    
    public void Sell()
    {
        UI.gold += GetTowerWorth() / 2;
        UI.RefreshGoldAmount();
        Destroy(gameObject);
        TowerUI.SetActive(false);
        rangeCircle.SetActive(false);
        isUIActive = false;
        UI.SetTowerUI(false);
        cursorCrosshair.sprite = cursorSprite;
    }
}
