/*

////  MOVEMENT 
Run
Step Back
Walk Upsidedown

////  ADD FORCE
ShortJump
Punch Impulse

//// TRIGGER ACTIONS
Nulo-Attack
Call Birdbot

////  AUTOMATED ACTIONS 
Idle
Fall
Rodar

    ## PENDINGS

    - [x] Run
    - [ ] Step Back
    - [ ] Walk Upsidedown
    - [x] ShortJump
    - [ ] Punch Impulse
    - [x] Nulo-Attack
    - [ ] Call Birdbot
    - [ ] Idle
    - [ ] Fall
    - [ ] Rodar
    - [ ] OnGround
*/


using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public Animator controller;

    void Start()
    {
        InputManagerController.OnMove += PlayMoveAnimation;
        PlayerController.OnHit += PlayHitAnimation;
        InputManagerController.OnJump += PlayJumpAnimation;
        PlayerController.OnGround += SetGroundAnimation;
        InputManagerController.OnAttack += PlayAttackAnim;
    }

    private void PlayAttackAnim()
    {
        controller.SetTrigger("OnAttack1");
    }

    private void SetGroundAnimation(bool value)
    {
        controller.SetBool("IsGrounded", value);
    }

    private void PlayJumpAnimation()
    {
        controller.SetTrigger("OnJump");
    }

    private void PlayMoveAnimation(Vector2 moveInput)
    {
        /*if(moveInput.x != 0)
            controller.SetBool("IsMoving", true);
        else
            controller.SetBool("IsMoving", false);*/

        controller.SetBool("IsMoving", moveInput.x != 0 ? true : false);
        Debug.Log("IsMoving" + moveInput.x);
        //GetComponent<SpriteRenderer>().flipX = (moveInput.x == -1 && moveInput.x !=0) ? true :false;
        GetComponent<SpriteRenderer>().flipX = (moveInput.x == -1) ? true : false;
    }

    private void PlayHitAnimation()
    {
        controller.SetTrigger("OnHit");
    }

    void Update()
    {

    }
}
