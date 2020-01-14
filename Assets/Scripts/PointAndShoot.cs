using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject player;
    public Vector3 target;
    public GameObject spellPrefab;
    public GameObject hand;
    public float spellSpeed;
    public GameObject spellStart;
    private bool isOverUI = false;
    private PlayerScript _playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        spellSpeed = spellPrefab.GetComponent<SpellScript>().spellSpeed;
        Cursor.visible = false;
        _playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector3(target.x, target.y);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        hand.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);


        if (Input.GetMouseButtonDown(0) && !isOverUI && !_playerScript.GetGameOver())
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            FireBullet(direction, rotationZ+90);
        }
    }

    void FireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(spellPrefab) as GameObject;
        var tmp = b.GetComponent<SpellScript>();
        tmp.damage += _playerScript.GetBonusDamage();
        tmp.travelTime += _playerScript.GetBonusRange();
        b.transform.position = spellStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * spellSpeed;
    }

    public void SetIsOverUI(bool value)
    {
        isOverUI = value;
    }
}
