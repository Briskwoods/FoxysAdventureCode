using System.Runtime.Versioning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed = 5;
    //public float rotateSpeed = 5;
    private Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x, transform.position.y), moveSpeed * Time.deltaTime);
        //Vector2 dir = target.transform.position - transform.position;
        //dir.Normalize();
        //rb.AddForce(dir*1000, ForceMode2D.Force);
        animator.SetFloat("Speed", Mathf.Abs(moveSpeed));
        
        if (transform.position.x < target.transform.position.x ){
            sprite.flipX =  true;
        }
        else if (transform.position.x > target.transform.position.x ){
            sprite.flipX = false;
        }
    }
}
