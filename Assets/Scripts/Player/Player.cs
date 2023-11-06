using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float currTemp;
    public float dashForce = 10f; 
    public float dashDuration = 0.2f; 
    public float dashCooldown = .1f; 

    private Rigidbody2D rb;
    public bool isDashing = false;
    public int maxNumDashes = 2;
    private int numDashes = 2;
    public float speed = 1f;
    public float jumpPower = 1f;
    public bool isGrounded;

    public static float temp;
    public float freezeTemp;
    public float freezeRate;
    public Image tempBar;
    public static Player instance;

    public LayerMask platformLayer;
    public Sprite sprite;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        AddFreeze();
        UpdateFreezeBar();
        SetGrounded();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        numDashes = maxNumDashes;
        sprite = GetComponent<SpriteRenderer>().sprite;
    }
    
    public void Move(Vector2 movement)
    {
        if (!isDashing)
        {
            rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        }
        
    }

    public void Dash(Vector2 direction)
    {
        if (numDashes > 0)
        {
            StartCoroutine(DashCor(direction));
        }
    }
   
    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        numDashes = maxNumDashes;
    }

    IEnumerator DashCor(Vector2 dashDirection)
    {
        numDashes = numDashes - 1;
        isDashing = true;
        rb.AddForce(dashDirection * dashForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(dashDuration);

        rb.velocity = Vector2.zero;
        isDashing = false;
    }

    public void AddFreeze()
    {
        temp = temp + Time.deltaTime * freezeRate;
    }

    public static void HitProjectile(float freezeAmount)
    {
        temp = temp + freezeAmount;
    }

    private void UpdateFreezeBar()
    {
        float amount = 1 - ((freezeTemp - temp) / freezeTemp);
        float clampedFillAmount = Mathf.Clamp(amount, 0f, 1f);

        tempBar.fillAmount = clampedFillAmount;
    }
    void SetGrounded()
    {
        // Perform a downward raycast to check if the player is above a platform
        float raycastDistance = 0.2f; // Adjust this based on your platform's thickness
        RaycastHit2D hit =  Physics2D.Raycast(transform.position, Vector3.down, raycastDistance, platformLayer);
        if (hit.collider!=null)
        {
            isGrounded = true;
            //rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        else
        {
            isGrounded = false;
        }
    }

}
