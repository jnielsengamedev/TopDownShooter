using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;

    [SerializeField] private float moveSpeed = 5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = MathF.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    public void TakeDamage(float damageAmount)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
