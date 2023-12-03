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

    }
    public void Update()
    {
        if(isAlive){
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

        // if (Keyboard.){
        //     rb.velocity = new Vector2(input.x * moveSpeed*4, input.y * moveSpeed*4);
        // }
        // animator.SetBool("isMoving", isMoving);

        // slider.value = health;
        }
        
    }

    public void Respawn(){
        Awake();
        

    }
    

    public void PlayerDie(){
        animator.SetBool("IsAlive", false);
        fill.SetActive(false);
        isAlive = false;
        inGameUiController.DeathScreen();
    }
    

    public Vector2 GetFacingDirection(){
        float moveX = animator.GetFloat("moveX");
        float moveY = animator.GetFloat("moveY");
        Vector2 facingDirection = new Vector2(moveX, moveY).normalized;
        return facingDirection;
    }

    // IEnumerator Move(Vector3 targetPos){
    //     isMoving = true;
    //     while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){
    //         transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    //         yield return null;
    //     }
    //     transform.position = targetPos;
    //     isMoving = false;
    // }

   
    // private bool IsWalkable(Vector3 targetPos){
    //     if(Physics2D.OverlapCircle(targetPos, 0.25f, solidObjectsLayer)) {
    //         return false;
    //     }
    //     return true;
    // }

    public void GetHit(Vector2 knockback){
        // animator.SetTrigger("Hit");
        Debug.Log(health);
        rb.AddForce(knockback);
        inGameUiController.HitScreen();
    } 

    public bool CheckIsAlive(){
        return isAlive;
    }

   

    private void Attack()
    {
        animator.SetTrigger("swordAttack");
        
    }
        
    


}
