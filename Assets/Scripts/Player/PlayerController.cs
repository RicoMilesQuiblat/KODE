using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;  
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource attackSoundEffect, dashSoundEffect, deathSoundEffect, winSoundEffect, ouchSoundEffect;
    public float moveSpeed = 50f;
    public float maxSpeed = 8f;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    public LayerMask solidObjectsLayer;
    public LayerMask monsterLayer;
    public LayerMask teleporterLayer;
    public GameController gameController;

    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;
    private Vector2 lastMovementDirection = Vector2.down; // default facing direction


    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public InGameUiController inGameUiController;
    public InGameUiController HitAnim;
    public InGameUiController LowAnim;

    public bool isAlive = true;

    public GameObject levelUpEffect;
    private Rigidbody2D rb;

    public SwordAttack swordAttack;

    public Slider slider;
    public bool isLowHealth = false;
    public GameObject fill;

    private Vector2 startPosition;
    private bool hasRecoveredFromLowHealth;
    public EnemyController enemyController;
    private bool facingRight=false;
    private bool facingUp=false;
    public LivesController livesController;

    private Scene currentScene;

    private bool canAttack = true;
    private bool wasLowHealth = false;
    private bool isAttacking = false;
    private bool useMouseForDirection = true;

    private float maxHP = 10f;

    public float Health{
        set{
            health = value;

            if(health <= 0){
                PlayerDie();
            }
        }
        get {
            return health;
        }
    }

    public Slider expSlider;
    public Text expText;
    public float currentExp = 0;
    public float currentMaxExp = 100;

    public float level = 1;
    
    private float lives = 3f;
    public float health;


    private void Awake(){
        currentScene = SceneManager.GetActiveScene();
        health = 10f;
        slider.maxValue = maxHP;
        slider.value = maxHP;
        expText.text = "Lvl. " + level;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        fill.SetActive(true);
        animator.SetBool("IsAlive", true);

        if(currentScene.name == "FlowChart"){
            startPosition = new Vector2(-9.43f, 3.16f);
            
        }
        expSlider.maxValue = currentMaxExp;
        expSlider.value = currentExp;
        transform.position = startPosition;
        isAlive = true;
        Debug.Log(lives);

    }

    public void SetCanAttack(bool setter){
        canAttack = setter;
    }
    public void Update()
    {   
        CheckForControlSchemeChange();
        if(currentExp >= currentMaxExp){
            LevelUp();
            Debug.Log(currentMaxExp);
        }

        if(isAlive && lives > 0){
            Vector2 facingDirection = GetFacingDirection();
            animator.SetFloat("moveX", facingDirection.x);
            animator.SetFloat("moveY", facingDirection.y);
            teleportDirection = new Vector2(
            input.x != 0 ? Mathf.Sign(input.x) : 0,
            input.y != 0 ? Mathf.Sign(input.y) : 0
            );

            bool isCurrentlyLowHealth = health < 4f;
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            Vector2 movementDirection = new Vector2(
                input.x != 0 ? Mathf.Sign(input.x) : 0,
                input.y != 0 ? Mathf.Sign(input.y) : 0
            );
            if (isCurrentlyLowHealth != wasLowHealth) {
                wasLowHealth = isCurrentlyLowHealth;

                if (isCurrentlyLowHealth) {
                    LowAnim.lowhpscreen();
                    hasRecoveredFromLowHealth = false; // Reset recovery flag when health becomes low
                } else {
                    // Check if we have not recovered from low health and health is acceptable
                    if (!hasRecoveredFromLowHealth && health >= 4f) {
                        LowAnim.lowhpscreenCLOSE();
                        hasRecoveredFromLowHealth = true; // Set recovery flag
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Teleport(2f);
            }
            
            if (input != Vector2.zero)
            {
                lastMovementDirection = new Vector2(input.x, input.y).normalized;

                rb.velocity = new Vector2(input.x * moveSpeed, input.y * moveSpeed);

                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                int count = rb.Cast(
                    input,
                    movementFilter,
                    castCollisions,
                    moveSpeed * Time.fixedDeltaTime + collisionOffset
                );
                isMoving = true;

                
                // Check the facing direction
            }
            else
            {
                isMoving = false;
            }

             

             if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                
                inGameUiController.DashScreen();
            }
            if (!isAttacking) {
            facingDirection = GetFacingDirection();
            animator.SetFloat("moveX", facingDirection.x);
            animator.SetFloat("moveY", facingDirection.y);
        }
            if(canAttack && (Input.GetKeyDown(KeyCode.J) || Input.GetMouseButtonDown(0))){
            StartCoroutine(HandleAttack());
            }
            
            animator.SetBool("isMoving", isMoving);
            slider.value = health;
            
            
        }
        if(!isAlive){
           LowAnim.lowhpscreenCLOSE();
        }

        if(lives == 0){
            GameOver();
        }

        

    }

    public void GainExp(float exp){
        currentExp += exp;
        expSlider.value = currentExp;
        Debug.Log(currentExp);
    }
    private void LevelUp(){
        StartCoroutine(StartLevelUpEffect());   
        level += (float) Math.Round(((double) currentExp) / ((double)currentMaxExp));
        currentExp -= currentMaxExp;
        currentMaxExp = currentMaxExp * 1.5f;
        maxHP = maxHP * 1.2f;
        slider.maxValue = maxHP;
        health = maxHP;
        swordAttack.AddDamage(level);
        expSlider.maxValue = currentMaxExp;
        expSlider.value = currentExp;
        expText.text = "Lvl. " + level;
        Debug.Log(level);

    }
    
    private IEnumerator StartLevelUpEffect(){
        levelUpEffect.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        levelUpEffect.SetActive(false);

    }
    private void RotateTowardsMouse()
{
    // Get the mouse position in world space
    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

    // Calculate the direction from the player to the mouse
    Vector2 direction = mousePosition - new Vector2(transform.position.x, transform.position.y);

    // Update the player's rotation to face this direction
    // You might need to adjust this based on your game's orientation and coordinate system
    transform.up = direction;
}

    private void Teleport(float distance)
    {
        Vector2 teleportPosition = rb.position + teleportDirection * distance;

        if (IsWalkable(teleportPosition))
        {
            StartCoroutine(TeleportCoroutine(teleportPosition));
        }
    }

    private bool IsWalkable(Vector2 targetPos)
    {
        // Add your logic to check if the target position is walkable
        // You may want to use Physics2D.OverlapCircle or other methods based on your game design.
        // For now, let's assume any position is walkable.
        return true;
    }

    private IEnumerator TeleportCoroutine(Vector2 targetPos)
    {
        dashSoundEffect.Play();
        isMoving = true;

        transform.position = targetPos;

        yield return null; 

        isMoving = false;

    }


    public void Respawn(){

        Awake();
        

    }
    

    public void PlayerDie(){
        deathSoundEffect.Play();
        animator.SetBool("IsAlive", false);
        isAlive = false;
        Removelife();
        if(lives > 0){
        inGameUiController.DeathScreen();
        }else{
            inGameUiController.GameOverScreen();
        }

    }

    public void Removelife(){
        lives -= 1;
        health = 10f;
        slider.value = health;
        livesController.RemoveLives();
    }
    

    private Vector2 GetFacingDirection()
    {
        if (useMouseForDirection)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 direction = (mousePosition - new Vector2(transform.position.x, transform.position.y)).normalized;
            return new Vector2(Mathf.Abs(direction.x) > Mathf.Abs(direction.y) ? (direction.x >= 0 ? 1 : -1) : 0, Mathf.Abs(direction.y) > Mathf.Abs(direction.x) ? (direction.y >= 0 ? 1 : -1) : 0);
        }
        else
        {
            if (input.x == 0 && input.y == 0)
                return lastMovementDirection; 
            else
                return new Vector2(input.x != 0 ? Mathf.Sign(input.x) : 0, input.y != 0 ? Mathf.Sign(input.y) : 0);
        }
    }


    public void GetHit(Vector2 knockback){
        Debug.Log(health);
        rb.AddForce(knockback);
        inGameUiController.HitScreen();
        ouchSoundEffect.Play();
    } 

    public bool CheckIsAlive(){
        return isAlive;
    }

    public void GameOver(){
        Debug.Log("Game Over");
    }
   

    private void Attack()
    {
        attackSoundEffect.Play();
        animator.SetTrigger("swordAttack");
        
    }

    public GameController GameController
    {
        get => default;
        set
        {
        }
    }

    public Vector2 teleportDirection { get; private set; }

    private IEnumerator HandleAttack() {
    isAttacking = true;

    Vector2 attackDirection = input.x == 0 && input.y == 0 ? lastMovementDirection : GetFacingDirection();
    
    animator.SetFloat("moveX", attackDirection.x);
    animator.SetFloat("moveY", attackDirection.y);


    attackSoundEffect.Play();

    animator.SetTrigger("swordAttack");

    if(attackDirection == Vector2.right){
        swordAttack.AttackRight();
    }else if (attackDirection == Vector2.left){
        swordAttack.AttackLeft();
    }else if (attackDirection == Vector2.up){
        swordAttack.AttackUp();
    }else if (attackDirection == Vector2.down){
        swordAttack.AttackDown();
    }

    yield return new WaitForSeconds(0); 

    isAttacking = false;
}

private void CheckForControlSchemeChange()
{
    if (Input.GetKeyDown(KeyCode.Alpha0))
    {
        useMouseForDirection = !useMouseForDirection;
    }
}




}
