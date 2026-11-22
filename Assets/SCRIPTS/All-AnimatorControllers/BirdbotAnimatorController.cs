using UnityEngine;

public class BirdbotAnimatorController : MonoBehaviour
{
    public Animator controller;


    void Start()
    { 
        InputBirdbotController.Fly += ActivateFlyAnimation;
        BirdbotInputController.OnHit += ActivateHitAnimation;
        InputBirdbotController.FlyAway += ActivateFlyAwayAnimation;
        InputBirdbotController.Jump += ActivateJumpAnimation;
        ManagerInputController.BirdAppears += ActivateAppearsAnim;
    }

    private void ActivateFlyAnimation(Vector2 moveInput)
    {
        if (moveInput.x != 0)
            controller.SetBool("IsBMoving", true);
        else
            controller.SetBool("IsBMoving", false);

        controller.SetBool("IsBMoving", moveInput.x != 0 ? true : false);
        Debug.Log("IsBMoving" + moveInput.x);
        GetComponent<SpriteRenderer>().flipX = (moveInput.x == -1) ? true : false;
    }

    private void ActivateJumpAnimation()
    {
        controller.SetTrigger("OnJump");

    }

    private void ActivateHitAnimation()
    {
        controller.SetTrigger("OnHit");
    }

    private void ActivateFlyAwayAnimation()
    {
        controller.SetTrigger("FinishRide");
    }

    private void ActivateAppearsAnim()
    {
        controller.SetTrigger("BirdAppears");
    }

}
