using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopupScript : MonoBehaviour
{
    private float t;
    private float timer = 0;
    private Vector3 startingPos;
    private Vector3 endPos;

    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        offset = Random.Range(-1, 1);
        endPos = new Vector3(startingPos.x+offset, startingPos.y + 1, startingPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        t += Time.deltaTime/0.2f;
        transform.position = Vector3.Lerp(startingPos, endPos, t);
        if (transform.position == endPos && timer > 0.3f)
        {
            Destroy(gameObject);
        }
    }

    public void SetText(float damage)
    {
        gameObject.GetComponent<TextMeshPro>().text = $"{damage}";
    }
}
