using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    public LayerMask solidObjectsLayer;
    public LayerMask monsterLayer;

    public GameController gameController;

    private void Awake(){
        animator = GetComponent<Animator>();
        Debug.Log("I miss her");
    }
    public void Update()
    {
        if(!isMoving){
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

        if (input.x != 0){
            input.y = 0;
        }
        if (input != Vector2.zero){
            Debug.Log("moving");
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
            var targetPos = transform.position;

            targetPos.x += input.x;
            targetPos.y += input.y;
            if(IsWalkable(targetPos)){

            StartCoroutine(Move(targetPos));
            }
        }
        }
        animator.SetBool("isMoving", isMoving);
        
    }

    IEnumerator Move(Vector3 targetPos){
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
        CheckForEncounters();
    }

    private bool IsWalkable(Vector3 targetPos){
        if(Physics2D.OverlapCircle(targetPos, 0.05f, solidObjectsLayer)) {
            return false;
        }
        return true;
    }

    private void CheckForEncounters(){
        if(Physics2D.OverlapCircle(transform.position, 0.2f, monsterLayer) != null){
            Debug.Log("Encountered a monster");
            gameController.BattleMode();
        }
    }
}
