
using UnityEngine;

public class ClocksiniesterAnimatorController : MonoBehaviour
{
    public Animator controller;

    void Start()
    {
        ClocksiniesterInputController.OnGround += SetGroundAnimation;
        InputClocksiniesterController.OnWalkUpsidedown += PlayMoveAnimation;
        InputClocksiniesterController.OnCSShortJump += PlayJumpAnimation;
        InputClocksiniesterController.OnPunchImpulse += PlayPunchImpulseAnimation;
        InputClocksiniesterController.OnCSSpin += PlaySpinAnimation;
        InputClocksiniesterController.OnAttack += PlayAttackAnimation;       //puede que el timbre lo que active script(????        
        InputClocksiniesterController.OnSpeedGear += PlaySpeedGearAnimation; //puede que el timbre lo que active script(?   ????     
        ClocksiniesterInputController.OnCSHit += PlayHitAnimation;
    }


    private void SetGroundAnimation(bool value)
    {
        controller.SetBool("OnLand", value);
    }

    private void PlayMoveAnimation(Vector2 moveInput)
    {
        if (moveInput.x != 0)
            controller.SetBool("IsCSMoving", true);
        else
            controller.SetBool("IsCSMoving", false);

        controller.SetBool("IsCSMoving", moveInput.x != 0 ? true : false);
        Debug.Log("IsCSMoving" + moveInput.x);
        GetComponent<SpriteRenderer>().flipX = (moveInput.x == -1) ? true : false;
    }

    private void PlayJumpAnimation()
    {
        controller.SetTrigger("OnJump");
    }
    private void PlayPunchImpulseAnimation()
    {
        controller.SetTrigger("OnCSPunchImpulse");
    }

    private void PlaySpinAnimation()
    {
        controller.SetTrigger("OnSpin");
    }

    private void PlayAttackAnimation()
    {
        controller.SetTrigger("OnAttack");
    }

    private void PlaySpeedGearAnimation()
    {
        controller.SetTrigger("OnSpeedGear");
    }

    private void PlayHitAnimation()
    {
        controller.SetTrigger("OnHit");
    }

    //ON DEATH cocinandose todavia no puede morir el player


}
