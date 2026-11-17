using System;
using UnityEngine;

public class ClockborgAnimatorController : MonoBehaviour
{
    public Animator controller;

    void Start()
    {
        ClockborgInputController.OnLand += SetGroundAnimation;
        InputClockborgController.OnMovement += PlayMoveAnimation;
        InputClockborgController.OnStepBack += PlayStepBackAnimation;
        InputClockborgController.OnCBShortJump += PlayJumpAnimation;
        InputClockborgController.OnCBSpin += PlaySpinAnimation;
       // TransformationInputController.IsCalled += PlayCallBirdbotAnimation;
        ClockborgInputController.OnHit += PlayHitAnimation;
    }


    private void SetGroundAnimation(bool value)
    {
        controller.SetBool("OnLand", value);
    }

    private void PlayMoveAnimation(Vector2 moveInput)
    {
        if (moveInput.x != 0)
            controller.SetBool("IsMoving", true);
        else
            controller.SetBool("IsMoving", false);

        controller.SetBool("IsMoving", moveInput.x != 0 ? true : false);
        Debug.Log("IsMoving" + moveInput.x);
        GetComponent<SpriteRenderer>().flipX = (moveInput.x == -1) ? true : false;
    }

    private void PlayStepBackAnimation()
    {
        controller.SetTrigger("OnStepBack");
    }

    private void PlayJumpAnimation()
    {
        controller.SetTrigger("OnJump");
    }

    private void PlaySpinAnimation()
    {
        controller.SetTrigger("OnSpin");
    }

    private void PlayCallBirdbotAnimation()
    {
        controller.SetTrigger("IsCalled");
    }


    private void PlayHitAnimation()
    {
        controller.SetTrigger("OnHit");
    }

    //ON DEATH cocinandose todavia no puede morir el player


}
