using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AIScriptRB2D : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    public SpriteRenderer sr;
    private Vector2 _movement;
    public Animator animator;
    
    private static readonly int Speed = Animator.StringToHash("Speed");

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        _movement = direction;
        
        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        
        MoveCharacter(_movement);
  
    }

    void MoveCharacter(Vector2 direction)
    {
        var position = transform.position;
        var playerPosition = player.position;
        var distanceX = Math.Abs(playerPosition.x - position.x);
        var distanceY = playerPosition.y - position.y;
        if (distanceX > 1.75f || Math.Abs(distanceY) > 1.87f || (distanceY>0 && Math.Abs(distanceY) > 1.5f))
        {
            animator.SetFloat(Speed, 1);
            position = Vector2.Lerp(position,
                (Vector2) position + (Time.deltaTime * moveSpeed * direction), Time.time);
            transform.position = position;
        }
        else
        {
            animator.SetFloat(Speed, 0);
        }
    }
}
