using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
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

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public InGameUiController inGameUiController;
    public InGameUiController HitAnim;

    public bool isAlive = true;

    private Rigidbody2D rb;

    public SwordAttack swordAttack;

    public Slider slider;

    public GameObject fill;

    private Vector2 startPosition;

    public EnemyController enemyController;
    private bool facingRight=false;
    private bool facingUp=false;
    public LivesController livesController;


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

    
    private float lives = 3f;
    public float health;
    

    private void Awake(){
        health = 10f;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        fill.SetActive(true);
        animator.SetBool("IsAlive", true);
        Debug.Log("I miss her");
        startPosition = new Vector2(0.5f, 0.8f);
        transform.position = startPosition;
        isAlive = true;
        Debug.Log(lives);

    }
    public void Update()
    {
        if(isAlive && lives > 0){
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Teleport(2f);
            }
            if (input != Vector2.zero)
            {
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

              if (Input.GetMouseButtonDown(0)){
            Debug.Log("Attacking");
            Vector2 facingDirection = GetFacingDirection();
            if(facingDirection == Vector2.right){
                swordAttack.AttackRight();
            }else if (facingDirection == Vector2.left){
                swordAttack.AttackLeft();
            }else if (facingDirection == Vector2.up){
               swordAttack.AttackUp();
            }else if (facingDirection == Vector2.down){
                swordAttack.AttackDown();
            }
            Attack();
        }

            animator.SetBool("isMoving", isMoving);
            slider.value = health;
        }

        if(lives == 0){
            GameOver();
        }
    }

    private void Teleport(float distance)
    {
        Vector2 facingDirection = GetFacingDirection();
        Vector2 teleportPosition = rb.position + facingDirection * distance;

        // Check if the teleportPosition is walkable (modify this based on your game logic)
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
        isMoving = true;

        // Optional: Add any teleportation animation or effects here

        // Teleport the player to the target position
        transform.position = targetPos;

        yield return null; // Wait for the end of the frame

        isMoving = false;

        // Optional: Add any teleportation animation or effects here
    }


    public void Respawn(){

        Awake();
        

    }
    

    public void PlayerDie(){
        animator.SetBool("IsAlive", false);
        isAlive = false;
        Removelife();
        inGameUiController.DeathScreen();

    }

    public void Removelife(){
        lives -= 1;
        livesController.RemoveLives();
    }
    

    public Vector2 GetFacingDirection(){
        float moveX = animator.GetFloat("moveX");
        float moveY = animator.GetFloat("moveY");
        Vector2 facingDirection = new Vector2(moveX, moveY).normalized;
        return facingDirection;
    }

    public void GetHit(Vector2 knockback){
        // animator.SetTrigger("Hit");
        Debug.Log(health);
        rb.AddForce(knockback);
        inGameUiController.HitScreen();
    } 

    public bool CheckIsAlive(){
        return isAlive;
    }

    public void GameOver(){
        Debug.Log("Game Over");
    }
   

    private void Attack()
    {
        animator.SetTrigger("swordAttack");
        
    }
        
    


}
