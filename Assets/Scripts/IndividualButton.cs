using UnityEngine;

public class IndividualButton : MonoBehaviour
{
    private Animator btnSpriteAnimator;
    private DoubleButtons DoubleButtonsScript;

    private void Start()
    {
        btnSpriteAnimator = GetComponentInChildren<Animator>();
        DoubleButtonsScript = GetComponentInParent<DoubleButtons>();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //DoubleButtonsScript.ButtonsPressed++;
        DoubleButtonsScript.ButtonsPressed+=1;
        btnSpriteAnimator.SetBool("btnPressed", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //DoubleButtonsScript.ButtonsPressed--;
        DoubleButtonsScript.ButtonsPressed-=1;
        btnSpriteAnimator.SetBool("btnPressed", false);
    }
}
