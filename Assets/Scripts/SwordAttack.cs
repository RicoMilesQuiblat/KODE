using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordAttack : MonoBehaviour
{
   
   
    public Collider2D swordCollider;
    private float damage = 2f;
    public float knockbackForce = 500f;
    public Scene currentScene;
    

    public void AddDamage(float level){
        damage += 1 + (level / 10);
    }

    public void RemoveDamage(float level){
        damage -= 1 + (level / 10);
    }

    private void Start(){
       currentScene = SceneManager.GetActiveScene();
    }

    
    public void AttackRight() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(0.49f , 0);
        // StartCoroutine(StopAttackAfterDuration());

    }
    public void AttackLeft() {
      
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(0.49f * -1 , 0);
        // StartCoroutine(StopAttackAfterDuration());
    }
    public void AttackUp() {
       
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(-0.02f , -0.56f * -1);
        // StartCoroutine(StopAttackAfterDuration());
    }
    public void AttackDown() {
        
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(-0.02f, -0.56f);
        // StartCoroutine(StopAttackAfterDuration());
    }

    public void StopAttack(){
        swordCollider.enabled = false;
    }

    // private IEnumerator StopAttackAfterDuration()
    // {
    //     yield return new WaitForSeconds(0.2f);
    //     StopAttack();
    // }

    // private void OnCollisionEnter2D(Collision2D col){
    //     if(col.collider.tag == "enemy"){
    //         Debug.Log("ouch");
    //          EnemyController enemy = col.collider.GetComponent<EnemyController>();

    //         if(enemy != null){
    //             Debug.Log("ouch");
    //              enemy.Health -= damage;
    //              Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
    //              Vector2 direction = (Vector2) (parentPosition - col.gameObject.transform.position).normalized;
    //              Vector2 knockback = direction * knockbackForce;
    //              enemy.GetHit(knockback);
    //          }
    //     }
    // }

    

    private void OnTriggerEnter2D(Collider2D other){
        
        if (other.tag == "enemy")
        {
            
            EnemyController enemy = other.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.Health -= damage;

            
                TipPopout tip = TipPopout.Create(transform.position, Math.Round(damage).ToString(), 5f, Color.white,(float).5);
                

                Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
                Vector2 direction = (Vector2)(parentPosition - other.gameObject.transform.position).normalized;
                Vector2 knockback = direction * knockbackForce;
                enemy.GetHit(knockback * -1);
            }
        }
    }
    

}
