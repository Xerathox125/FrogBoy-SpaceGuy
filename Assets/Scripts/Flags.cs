using UnityEngine;

public class Flags : MonoBehaviour
{
    private Animator flagAnimator;


    void Start()
    {
        flagAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NinjaFrog") || collision.gameObject.CompareTag("VirtualGuy"))
        {
            flagAnimator.SetBool("OnFlag", true);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NinjaFrog") || collision.gameObject.CompareTag("VirtualGuy"))
        {
            flagAnimator.SetBool("OnFlag", false);
        }
    }
}
