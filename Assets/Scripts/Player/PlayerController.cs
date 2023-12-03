using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public bool isAlive = true;

    private Rigidbody2D rb;

    public SwordAttack swordAttack;

    public Slider slider;

    public GameObject fill;

    private Vector2 startPosition;

    public EnemyController enemyController;

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

            if(input != Vector2.zero){
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
            }else{
                isMoving = false;
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
