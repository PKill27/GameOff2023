using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float currTemp;
   
    public Rigidbody2D rb;
    public float speed = 1f;
    public float jumpPower = 1f;
    public bool isGrounded;

    public float temp;
    public float freezeTemp;
    public float freezeRate;
    public Image tempBar;
    public Image foodBar;

    public float hunger;
    public float maxHunger;
    public float hungerRate;

    public static Player instance;
    public bool isFacingRight;

    public LayerMask platformLayer;
    public LayerMask treeLayer;
    public Sprite sprite;
    public Transform groundCheckPos;
    public float groundCheckRadius;
    public bool isJumping;
    public bool canJump;

    public Animator animator;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        AddFreeze();
        IncreaseHunger();
        SetGrounded();
    }

private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
 
        sprite = GetComponent<SpriteRenderer>().sprite;
        animator = GetComponent<Animator>();
    }
    
    public void Move(Vector2 movement)
    {
        SetGrounded();
        
        animator.SetBool("isWalking", true);
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        UpdateAngle();
    }

    private void UpdateAngle()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .1f);

        if (hit.collider != null)
        {
            Debug.DrawRay(hit.point, hit.normal, Color.red);

        }
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        isGrounded = false;
        canJump = false;
        isJumping = true;
    }

    
    public void IncreaseHunger()
    {
        hunger = hunger + Time.deltaTime * hungerRate;
        float amount = ((maxHunger - hunger) / maxHunger);
        float clampedFillAmount = Mathf.Clamp(amount, 0f, 1f);

        foodBar.fillAmount = clampedFillAmount;
    }
    public void AddFreeze()
    {
        temp = temp + Time.deltaTime * freezeRate;
        float amount = 1 - ((freezeTemp - temp) / freezeTemp);
        float clampedFillAmount = Mathf.Clamp(amount, 0f, 1f);

        tempBar.fillAmount = clampedFillAmount;
    }

    public void HitProjectile(float freezeAmount)
    {
        temp = temp + freezeAmount;

    }

    void SetGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, platformLayer);
        
        if (rb.velocity.y <= 0.0f)
        {
            isJumping = false;
        }

        if (isGrounded && !isJumping )
        {
            canJump = true;
        }
    }
    public void Eat()
    {
        hunger = Mathf.Max(hunger - 10, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckPos.position, groundCheckRadius);
    }
}
