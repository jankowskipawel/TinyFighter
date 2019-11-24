using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    Vector2 pos;
    Vector2 targetPos;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if (Vector3.Distance(transform.position, player.transform.position) > 1) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 
                speed * Time.deltaTime);
        }
    }
}
