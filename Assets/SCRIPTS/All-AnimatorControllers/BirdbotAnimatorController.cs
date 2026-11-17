using UnityEngine;

public class BirdbotAnimatorController : MonoBehaviour
{
    public Animator controller;


    void Start()
    { 
        InputBirdbotController.Fly += ActivateFlyAnimation;
        BirdbotInputController.OnHit += ActivateHitAnimation;
        //el timbre de desaparecer lo va a tocar transformation - paciencia  a que eso este

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

    private void ActivateHitAnimation()
    {
        controller.SetTrigger("OnHit");
    }




}
