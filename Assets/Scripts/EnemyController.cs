using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float damage = 1f;
    public float knockbackForce = 5000f;

    public Detection detectionZone;
    
    public bool canAttack = true;
    public float moveSpeed = 800f;

    public bool playerIsAlive;
    public ScrollController scrollController;
    private Vector2 dropPosition;

    public bool isFlipped = false;
  

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

    void FixedUpdate(){
        if(detectionZone.detectedObj.Count > 0){
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
        dropPosition = transform.position;
    }
    public void GetHit(Vector2 knockback){
        animator.SetTrigger("Hit");
        rb.AddForce(knockback);
    }

    public void Defeated(){
        Debug.Log("Defeated");
        animator.SetBool("isAlive", false);
    }

    public void RemoveEnemy(){
        if(scrollController){

            scrollController.DropScroll(dropPosition);
        }
        Destroy(gameObject);
        
    }

    public void Respawn(){
        Start();

    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.tag == "Player"){
            Debug.Log("ouch");
            PlayerController player = col.collider.GetComponent<PlayerController>();

            if(player != null && player.CheckIsAlive()){    
                if(canAttack){

                    Debug.Log("ouch");
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
    
}
