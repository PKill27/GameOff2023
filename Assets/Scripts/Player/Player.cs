using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMOD.Studio;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1f;
    public float jumpPower = 1f;
    public bool isGrounded;
    public bool isFacingLeftStart = false;

    public float temp;
    public float freezeTemp;
    public float freezeRate;

    public Image tempBar;
    public Image foodBar;
    public Image hpBar;

    public float hunger;
    public float maxHunger;
    public float hungerRate;

    public float hp;
    public float maxHp;

    public static Player instance;
    public bool isFacingRight;

    public LayerMask platformLayer;
    public LayerMask treeLayer;
    public Sprite sprite;
    public SpriteRenderer spriteRender;
    public Transform groundCheckPos;
    public float groundCheckRadius;
    private Vector2 forwardVector;
    public bool isJumping;
    public bool canJump;
    public bool isOnSlope;
    public bool isWalking;
    private float slopeAngle;
    private float prevSlopeAngle;
    private float sideAngleLeft;
    private float sideAngleRight;
    public Animator animator;
    public bool hasStartedEndGame;
    private float rotationResetimer;
    public PhysicsMaterial2D highFriction;
    public PhysicsMaterial2D regularFriction;
    public PhysicsMaterial2D noFriction;
    public Image[] freezeOverlay;
    public Transform[] checkpoints;
    private bool aboutToJump;
    public bool isGameOver = false;
    public GameObject gameOverPanel;
    public float freezeOverlayMultiplier = 1;
    public bool isTalking = false;
    public GameObject deadPlayer;
    public Material deadMat;
    public bool hasDied = false;
    public bool isInWater = false;
    public bool isInFire = false;
    public bool canBeSpirit = false;
    public float fallDistance;
    public float startFallDistance;
    private bool takingFallDamage;
    public GameObject spiritLight;
    public bool isEating = false;
    public int trashCollected;
    public float timeLoaded = 0f;
    private EventInstance playerFootsteps;
    public bool isPaused  = false;
    public bool canPickUpTrash;
    private float timeBetweenFoootstep;
    public GroundOption currentGround;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    protected void Update()
    {
        if (!isTalking && !isGameOver)
        {
            AddFreeze();
            IncreaseHunger();
            UpdateHpUi();
            SetGrounded();
            CheckFrontAngles();
            UpdateAngle();
            CheckEndGame();
            CheckFallDamage();
            timeLoaded += Time.deltaTime;
        }
        //UpdateSound();

    }
    private void CheckFallDamage()
    {
        float fallDamageThreshold = 1.6f;
        if (timeLoaded <= 1)//stops fall damage on loading in
        {
            fallDistance = 0;
        }
        if (fallDistance >= fallDamageThreshold && !takingFallDamage)
        {
            //if here taking fall dmg
            hp = hp - 40;
            fallDistance = 0;
            startFallDistance = rb.position.y;
            takingFallDamage = true;
            StartCoroutine(takeFallDamage());
        }
        else if (isGrounded)
        {
            startFallDistance = rb.position.y;
        }
        
        
    }
    
    public void PauseAllAnimations()
    {
        Animator[] allAnimators = FindObjectsByType<Animator>(FindObjectsSortMode.None);
        foreach (Animator animator in allAnimators)
        {
            if (animator != null)
            {
                // Get the current state information
                AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

                // Pause the animation by setting the speed to 0
                animator.speed = 0f;
            }
        }
    }

    // Method to unpause all animations
    public void UnpauseAllAnimations()
    {
        Animator[] allAnimators = FindObjectsByType<Animator>(FindObjectsSortMode.None);
        foreach (Animator animator in allAnimators)
        {
            if (animator != null)
            {
                // Unpause the animation by setting the speed back to 1
                animator.speed = 1f;
            }
        }
    }

    IEnumerator takeFallDamage()
    {
        yield return new WaitForSeconds(2f);
        takingFallDamage = false;
        fallDistance = 0;
        startFallDistance = rb.position.y;
    }
    private void UpdateHpUi()
    {
        if((temp / freezeTemp) >= .5)
        {
            hp = hp - (temp / freezeTemp) * .01f;
        }
        if ((hunger / maxHunger) >= .8)
        {
            hp = hp - (hunger / maxHunger) * .01f;
        }
        
        float amount = 1-((maxHp - hp) / maxHp);
        float clampedFillAmount = Mathf.Clamp(amount, 0f, 1f);

        hpBar.fillAmount = clampedFillAmount;
    }
   private void CheckEndGame()
    {
        if (hp <= 0)
        {
            if (isGrounded && !hasStartedEndGame && !hasDied && canBeSpirit)
            {
                isGameOver = true;
                hasStartedEndGame = true;
                animator.SetBool("isDead", true);
                StartCoroutine(WaitForDeath());
                
            }else if(isGrounded && !hasStartedEndGame && !hasDied && !canBeSpirit)

            {
                isGameOver = true;
                hasStartedEndGame = true;
                animator.SetBool("isDead", true);
                StartCoroutine(WaitForDeathMenu());
            }

                
        }
    }
    IEnumerator WaitForDeathMenu()
    {
        yield return new WaitForSeconds(4f);
        gameOverPanel.SetActive(true);
    }
    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(4f);
        //gameOverPanel.SetActive(true);
        temp = 0;
        hunger = 0;
        GameObject obj = Instantiate(deadPlayer,transform);
        obj.transform.parent = transform.parent;
        spriteRender.material = deadMat;
        isGameOver = false;
        animator.SetBool("isDead", false);
        hasStartedEndGame = false;
        hasDied = true;
        spiritLight.SetActive(true);


    }
    public void PlayFootstepSound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.RedPandaFootSteps, transform.position);
    }
    private void UpdateSound()
    {
        if (isTalking)
        {
            AudioManager.instance.SetParam("Text Box is Active",1);
        }
        else
        {
            AudioManager.instance.SetParam("Text Box is Active", 0);
        }
        if(isGrounded && isWalking && timeBetweenFoootstep >= .3)
        {
            //AudioManager.instance.PlayOneShot(FMODEvents.instance.RedPandaFootSteps, transform.position);
            timeBetweenFoootstep = 0;
        }
        timeBetweenFoootstep += Time.deltaTime;
    }

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = maxHp;
        sprite = GetComponent<SpriteRenderer>().sprite;
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        //playerFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.PlayerFootsteps);
        if (!MainManager.instance.isFirstScene)
        {
           
            LoadFromMainManager();
        }
        else
        {
            //transform.position = GetCheckPointandPos();
            MainManager.instance.isFirstScene = false;
        }
        if (SceneManager.GetActiveScene().name == "Platforming")
        {
             if (MainManager.instance.MainWorldIsFacingRight)
            {
                if(transform.localScale.x > 0)
                {
                    transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
                }
               
                isFacingRight = true;
            }

            else if (!MainManager.instance.MainWorldIsFacingRight)
            {
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
                }
                isFacingRight = false;
            }
        }
        else if (!isFacingLeftStart)
        {
            transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
            isFacingRight = true;
        }
        
        else if (isFacingLeftStart)
        {
                transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
                isFacingRight = false;
        }
            

        }

    private void LoadFromMainManager()
    {
        temp = MainManager.instance.temp;
        hunger = MainManager.instance.hunger;
        hp = MainManager.instance.hp;
        if(SceneManager.GetActiveScene().name == "Platforming")
        {
            transform.position = MainManager.instance.mainWorldPos;
        }
    }
    public void SaveToMainManager()
    {
        MainManager.instance.temp = temp;
        MainManager.instance.hunger = hunger;
        MainManager.instance.hp = hp;
    }

    public Vector2 GetCheckPointandPos()
    {
        return checkpoints[MainManager.instance.checkPoint].position;
    }

    public void Move(Vector2 movement)
    {
        if (!isGameOver&& !isTalking && !isEating)
        {
            SetGrounded();
            if(movement == Vector2.left)
            {
                if (isFacingRight)
                {
                    transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
                }
                isFacingRight = false;

            }else if(movement == Vector2.right)
            {
                if (!isFacingRight)
                {
                    transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
                }
                isFacingRight = true;
            }
            animator.SetBool("isWalking", true);

            if (isGrounded && !isOnSlope)
            {
                //no slope
                rb.velocity = new Vector2((movement.x * speed), rb.velocity.y);
            }
            else if (canJump && isOnSlope)
            {
                
                if(sideAngleLeft >= 70&& !isFacingRight)
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    animator.SetBool("isWalking", false);
                }
                else if (sideAngleRight >= 70 && isFacingRight)
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    animator.SetBool("isWalking", false);
                }
                else
                {
                    //on slope move in direction of slope
                    rb.velocity = -1 * new Vector2(speed * forwardVector.x * movement.x, speed * forwardVector.y * movement.x);
                    
                }
                
            }
            else if (!isGrounded)
            {
                //in air
                rb.velocity = new Vector2((movement.x * speed), rb.velocity.y);
            }
        }
    }
    private void CheckFrontAngles()
    {
        RaycastHit2D slopeHitRight = Physics2D.Raycast(groundCheckPos.position, Vector2.right, .25f, platformLayer);
        RaycastHit2D slopeHitLeft = Physics2D.Raycast(groundCheckPos.position, -Vector2.right, .25f, platformLayer);
        Debug.DrawRay(groundCheckPos.position, transform.right, Color.green);
        if (slopeHitRight)
        {
            isOnSlope = true;
            sideAngleRight = Vector2.Angle(slopeHitRight.normal, Vector2.up);

        }
        else if (slopeHitLeft)
        {
            isOnSlope = true;
            sideAngleLeft = Vector2.Angle(slopeHitLeft.normal, Vector2.up);
        }
        else
        {
            sideAngleLeft = 0.0f;
            sideAngleRight = 0.0f;
            isOnSlope = false;
        }
    }
    private void UpdateAngle()
    {
        //need to check vec2.down also cause if chr pointing up it doesnt know what to do
        rotationResetimer += Time.deltaTime;
        RaycastHit2D hit = Physics2D.Raycast(groundCheckPos.position, -transform.up, .5f,platformLayer);

        RaycastHit2D hitTrueDown = Physics2D.Raycast(groundCheckPos.position, Vector2.down, .5f, platformLayer);
        
        if (hit)
        {
            forwardVector = Vector2.Perpendicular(hit.normal).normalized;

            slopeAngle = Vector2.Angle(hit.normal, Vector2.up);

            if (slopeAngle != prevSlopeAngle)
            {
                isOnSlope = true;
            }

            prevSlopeAngle = slopeAngle;

            if (rotationResetimer >= .15)
            {
                if (slopeAngle >= 70)
                {
                    print("steep");
                }
                else
                {
                    rb.rotation = -Vector2.SignedAngle(hit.normal, Vector2.up);
                    rotationResetimer = 0;
                }
                
            }

        }else if (hitTrueDown)
        {
            forwardVector = Vector2.Perpendicular(hitTrueDown.normal).normalized;

            slopeAngle = Vector2.Angle(hitTrueDown.normal, Vector2.up);

            if (slopeAngle != prevSlopeAngle)
            {
                isOnSlope = true;
            }

            prevSlopeAngle = slopeAngle;

            if (rotationResetimer >= .15)
            {
                if(Vector2.Angle(hitTrueDown.normal, Vector2.up) >= 70)
                {
                    print("steep");
                }
                else
                {
                    rb.rotation = -Vector2.SignedAngle(hitTrueDown.normal, Vector2.up);
                    rotationResetimer = 0;
                }
                
            }

        }
        if ((Mathf.Abs(sideAngleLeft) >= 70 && !isFacingRight) || (Mathf.Abs(sideAngleRight) >= 70 && isFacingRight))
        {  
            rb.sharedMaterial = noFriction;
        }
        else if((isOnSlope && !isWalking))
        { 
            rb.sharedMaterial = highFriction;
        }
        else if (!isWalking)
        {
            rb.sharedMaterial = highFriction;
        }
        else
        {
            rb.sharedMaterial = regularFriction;
        }
    }

    public void Jump()
    {
        if (!aboutToJump && !isTalking && !isGameOver && !isEating&& isGrounded)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("landed", false);
            StartCoroutine(DelayJump());
        }
    }
    IEnumerator DelayJump()
    {
        aboutToJump =  true;
        yield return new WaitForSeconds(.2f);
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        isGrounded = false;
        canJump = false;
        isJumping = true;
        aboutToJump = false;
    }

    
    public void IncreaseHunger()
    {
        hunger = Mathf.Clamp(hunger + Time.deltaTime * hungerRate,0, maxHunger);
        float amount = ((maxHunger - hunger) / maxHunger);
        float clampedFillAmount = Mathf.Clamp(amount, 0f, 1f);

        foodBar.fillAmount = clampedFillAmount;
    }
    public void AddFreeze()
    {
        temp = Mathf.Clamp(temp + Time.deltaTime * freezeRate,0,freezeTemp);
        float amount = 1 - ((freezeTemp - temp) / freezeTemp);
        float clampedFillAmount = Mathf.Clamp(amount, 0f, 1f);

        tempBar.fillAmount = clampedFillAmount;

        SetOverlays();
        
        
    }
    public void SetOverlays()
    {
        SetOverlayAlpha();
      
    }
    void SetOverlayAlpha()
    { 
        float[] alpha = GetAlpha();

        Color overlayColor = freezeOverlay[0].color;
        overlayColor.a = alpha[0]/2;
        freezeOverlay[0].color = overlayColor;

        Color overlayColor1 = freezeOverlay[1].color;
        overlayColor1.a = alpha[1]/3;
        freezeOverlay[1].color = overlayColor1;

        Color overlayColor2 = freezeOverlay[2].color;
        overlayColor2.a = alpha[2]/4;
        freezeOverlay[2].color = overlayColor2;
    }
   private float[] GetAlpha()
    {
        float[] alpha = new float[3];
        
        float tempPercent = 1-((freezeTemp - temp) / freezeTemp);
        if (tempPercent <= .50)
        {
            alpha[0] = Mathf.Clamp01((tempPercent) / (.50f));
            alpha[1] = 0;
            alpha[2] = 0;
        }
        else if(tempPercent <= .75)
        {
            alpha[0] = 1;
            alpha[1] = Mathf.Clamp01((tempPercent - .50f) / (.75f - .50f));
            alpha[2] = 0;
        }
        else if (tempPercent <= .95)
        {
            alpha[0] = 1;
            alpha[1] = 1;
            alpha[2] = Mathf.Clamp01((tempPercent - .75f) / (.95f - .75f));
        }
        else if (tempPercent > .95)
        {
            alpha[0] = 1;
            alpha[1] = 1;
            alpha[2] = 1;
        }
        return alpha;
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
            //top of jump 
            isJumping = false;
            startFallDistance = Mathf.Max(startFallDistance,rb.position.y);
        }
        
        if (isGrounded && !isJumping && !aboutToJump) //&& !((Mathf.Abs(sideAngleLeft)>=70&&!isFacingRight) || (Mathf.Abs(sideAngleRight) >= 70&& isFacingRight)))
        {
            //is on ground
            animator.SetBool("isJumping", false);
            animator.SetBool("landed", true);
            animator.SetBool("isFalling", false);
            canJump = true;
            fallDistance = startFallDistance - rb.position.y;
        }
        else if (!isGrounded && canJump)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("landed", false);
            //startFallDistance = Mathf.Max(startFallDistance, rb.position.y);
        }
        

    }
    public void Eat()
    {
        isEating = true;
        hunger = Mathf.Max(hunger - 10, 0);
        animator.SetBool("isEating",true);
        StartCoroutine(WaitTillDoneEating());
    }
    IEnumerator WaitTillDoneEating()
    {
        yield return new WaitForSeconds(2f);
        isEating = false;
        animator.SetBool("isEating", false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckPos.position, groundCheckRadius);
    }
}
