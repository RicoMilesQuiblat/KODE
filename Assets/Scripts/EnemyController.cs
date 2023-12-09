using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    public enum EnemyType {
        Slime,
        Goblin,
        Dragon,
        Golem,
    }
    private Animator animator;
    private Rigidbody2D rb;
    public float damage;
    public float knockbackForce = 5000f;

    public Detection detectionZone;
    
    public bool canAttack = true;
    public float moveSpeed = 800f;

    public bool playerIsAlive;
    public ScrollController scrollController;
    public bool dropScroll = false;
    private Vector2 dropPosition;
    public EnemyType enemyType;
    public bool isFlipped = false;
    private Scene currentScene;
    public EnemySpawner enemySpawner;
    

    public PlayerController playerController;
    private bool canMove = true;
    private Vector2 startPosition;
    public float expDropped;

    public float Health{
        set{
            health = value;

            if(health <= 0){
                Defeated();
            }
        }
        get {
            return health;
        }
    }
    public float health;
    private void Start(){
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive", true);
       
    }

    private void OnEnable(){
        canMove = true;
        startPosition = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive", true);
        switch(enemyType){
            case EnemyType.Slime:
                health = 10f;
                expDropped = 10f;
                damage = 2f;
                break;
            case EnemyType.Goblin:
                health = 50f;
                expDropped = 100f;
                damage = 15f;
                moveSpeed = 1000f;
                break;
        }
    }

    void FixedUpdate(){
        if(canMove){
        if(detectionZone.detectedObj.Count > 0 && detectionZone){
            Vector2 direction = (detectionZone.detectedObj[0].transform.position - transform.position).normalized;
            Vector3 scale = transform.localScale;
            

            if(direction.x < 0 && !isFlipped){
                scale.x *= -1;
                transform.localScale = scale;
                isFlipped = true;
            }else if(direction.x > 0 && isFlipped){
                scale.x *= -1;
                transform.localScale = scale;
                isFlipped = false;
            } 
            
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
            animator.SetBool("IsMoving", true);
        }else{
            animator.SetBool("IsMoving", false);
        }
        }
       
        dropPosition = transform.position;
    }
    public void GetHit(Vector2 knockback){
        animator.SetTrigger("Hit");
        rb.AddForce(knockback);
    }

    public void Defeated(){
        canMove = false;
        animator.SetBool("isAlive", false);
    }

    public void RemoveEnemy(){
        
        playerController.GainExp(expDropped);
        enemySpawner.DieAndSpawn(gameObject, startPosition);
        
    }

    public void Respawn(){
        Start();

    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.tag == "Player"){
            PlayerController player = col.collider.GetComponent<PlayerController>();

            if(player != null && player.CheckIsAlive()){    
                if(canAttack){

                  player.Health -= damage;
                  Vector3 targetPosition = gameObject.GetComponent<Transform>().position;
                  Debug.Log(targetPosition);
                  Vector2 direction = (Vector2) (targetPosition - col.collider.transform.position).normalized;
                   Debug.Log(direction);
                  Vector2 knockback = direction * knockbackForce;
                  Debug.Log(knockback);
                  player.GetHit(knockback * -1);
                  
                }
              }
        }
    }

    public Detection Detection
    {
        get => default;
        set
        {
        }
    }

    public ScrollController ScrollController
    {
        get => default;
        set
        {
        }
    }
}
