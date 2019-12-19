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
    public Rigidbody2D rb;
    private bool isColided;
    public Transform basePosition;
    private Transform target;
    public bool isRanged;
    public float attackRange = 0;
    private float distanceFromBase;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsAttacking = Animator.StringToHash("isAttacking");
    private static readonly int IsDead = Animator.StringToHash("isDead");

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        basePosition = GameObject.Find("Base").transform;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        target = basePosition;
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        Vector3 direction = target.position - position;
        direction.Normalize();
        _movement = direction;
        if (isRanged)
        {
            distanceFromBase = Vector2.Distance(basePosition.position, position);
        }
        if (target.transform.position.x > transform.position.x && !animator.GetBool(IsDead))
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }

        if (!animator.GetBool(IsDead) && distanceFromBase >= attackRange)
        {
            MoveCharacter(_movement);
        }
        else
        {
            animator.SetFloat(Speed, 0);
            animator.SetFloat(IsAttacking, 1);
        }

        target = basePosition;
    }

    void MoveCharacter(Vector2 direction)
    {
        var position = transform.position;
        var targetPosition = target.position;
        var distanceX = Math.Abs(targetPosition.x - position.x);
        var distanceY = targetPosition.y - position.y;
        if (!isColided)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.gameObject.CompareTag("Player"))
        {
            isColided = true;
            animator.SetFloat(IsAttacking, 1);
        }*/
        
        if(collision.gameObject.CompareTag("Base"))
        {
            isColided = true;
            animator.SetFloat(IsAttacking, 1);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        /*if(collision.gameObject.CompareTag("Player"))
        {
            isColided = false;
            animator.SetFloat(IsAttacking, 0);
        }*/
        if(collision.gameObject.CompareTag("Base"))
        {
            isColided = true;
            animator.SetFloat(IsAttacking, 0);
        }
    }
}
