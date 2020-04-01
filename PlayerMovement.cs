using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    float HorizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false; 
    public Animator animator;
    private bool invincible = false;
    private Rigidbody2D player;
    private float fallSpeed;
    Renderer rend;
    Color C;
    public float damageValue = 1;    
 

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
        C = rend.material.color;
        Invoke("ResetInvulnerability", 2);
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        fallSpeed = player.velocity.y;
        
        animator.SetFloat("Fall", fallSpeed);
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;

            animator.SetBool("IsJumping", true);
        }
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        //Move Character
        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

void OnCollisionEnter2D(Collision2D collision)
{ 
    if (!invincible)
   {
     if (collision.transform.tag == ("Enemy"))
     {
        StartCoroutine("GetInvunerable");
        PlayerStats.Instance.TakeDamage(damageValue);
        animator.SetTrigger("IsHurt");
        invincible = true;
        Invoke("resetInvulnerability", 2);
      }
   }
   else{
       invincible = false;
   }
}
 void resetInvulnerability()
 {
    invincible = false;
    Physics2D.IgnoreLayerCollision(12, 8, false);
 }

 IEnumerator GetInvunerable(){
        Physics2D.IgnoreLayerCollision(12, 8, true);
        C.a = 0.5f;
        rend.material.color = C;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(12, 8, false);
        C.a = 1.0f;
        rend.material.color = C;


    }
}
