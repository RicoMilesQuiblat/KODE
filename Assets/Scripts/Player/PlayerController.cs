using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private bool tele_isActive;
    private Vector2 input;
    private Animator animator;
    public LayerMask solidObjectsLayer;
    public LayerMask monsterLayer;
    public LayerMask teleporterLayer;
    public GameController gameController;
    private static readonly int hashActiveTele = Animator.StringToHash("Activate_teleporter");

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

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, monsterLayer) != null)
        {
            Debug.Log("Encountered a monster");
            gameController.BattleMode();
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f, teleporterLayer);
        foreach (Collider2D collider in colliders)
        {
            Debug.Log("Encountered a teleporter");
            ActivateTeleporter();
        }

        if (colliders.Length == 0)
        {
            DeactivateTeleporter();
        }
    }




    private void ActivateTeleporter()
    {
        if (tele_isActive) return;

        tele_isActive = true;
        animator.SetTrigger(hashActiveTele);
    }

        private void DeactivateTeleporter()
    {
        if (!tele_isActive) return;

        tele_isActive = false;     
        animator.SetTrigger("Idle");  
    }
    public void Finish_TeleporterActivate() => tele_isActive = false;



}
