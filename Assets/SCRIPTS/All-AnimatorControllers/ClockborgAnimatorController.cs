using System;
using UnityEngine;

public class ClockborgAnimatorController : MonoBehaviour
{
    public Animator controller;
    private ClockborgInputController clockborgInputController;

    private void Awake()
    {
        clockborgInputController = GetComponent<ClockborgInputController>();

        if (clockborgInputController == null)
            Debug.LogError("No encontré ClockborgInputController en " + gameObject.name);
    }
    void Start()
    {
        ClockborgInputController.OnLand += SetGroundAnimation;
        InputClockborgController.OnMovement += PlayMoveAnimation;
        InputClockborgController.OnCBShortJump += PlayJumpAnimation;
        InputClockborgController.OnCBPunchImpulse += PlayPunchJumpAnimation;
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
        {
            if (clockborgInputController.IsOnLand)
            {    Debug.Log("clockborgInputController.IsOnLand");
            
                controller.SetBool("IsMoving", true);
            }

            else if (!clockborgInputController.IsOnLand)
            {
                Debug.Log("!clockborgInputController.IsOnLand");
                controller.SetBool("IsMoving", false);
                controller.SetBool("MoveOnAir", true);
            }
        }
        else
            controller.SetBool("IsMoving", false);
            controller.SetBool("MoveOnAir", false);

        controller.SetBool("IsMoving", moveInput.x != 0 ? true : false);
        controller.SetBool("MoveOnAir", moveInput.x != 0 ? true : false);
        //Debug.Log("IsMoving" + moveInput.x);
        GetComponent<SpriteRenderer>().flipX = (moveInput.x == -1) ? true : false;
    }

    private void PlayJumpAnimation()
    {
        controller.SetTrigger("OnJump");
        controller.SetBool("MoveOnAir",true);
    }

    private void PlayPunchJumpAnimation()
    {
        controller.SetTrigger("OnCBPunchImpulse");
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
