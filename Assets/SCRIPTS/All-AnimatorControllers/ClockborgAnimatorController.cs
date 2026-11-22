using System;
using UnityEngine;

public class ClockborgAnimatorController : MonoBehaviour
{
    public Animator controller;

    void Start()
    {
        ClockborgInputController.OnLand += SetGroundAnimation;
        InputClockborgController.OnMovement += PlayMoveAnimation;
        InputClockborgController.OnCBShortJump += PlayJumpAnimation;
        InputClockborgController.OnCBPunchImpulse += PlayPunchJumpAnimation;
        ClockborgInputController.OnSpin += PlaySpinAnimation;
        ClockborgInputController.OnHit += PlayHitAnimation;
        InputClockborgController.OnCallBirdbot += PlayCallAnimation;

    }
    private void SetGroundAnimation(bool value)
    {
        controller.SetBool("OnLand", value);
    }

    private void PlayMoveAnimation(Vector2 moveInput)
    {

        controller.SetBool("IsMoving", moveInput.x != 0 ? true : false);
        //Debug.Log("IsMoving" + moveInput.x);
        GetComponent<SpriteRenderer>().flipX = (moveInput.x == -1) ? true : false;
    }

    private void PlayJumpAnimation()
    {
        controller.SetTrigger("OnJump");
    }

    private void PlayPunchJumpAnimation()
    {
        controller.SetTrigger("OnCBPunchImpulse");
    }


    private void PlaySpinAnimation(bool value)
    {
        controller.SetBool("IsSpining", value);
    }

    private void PlayCallAnimation()
    {
        controller.SetTrigger("IsCalled");
    }


    private void PlayHitAnimation()
    {
        controller.SetTrigger("OnHit");
    }

    //ON DEATH cocinandose todavia no puede morir el player


}
