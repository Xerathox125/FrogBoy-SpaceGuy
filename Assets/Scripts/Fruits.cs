using System.Collections;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private Animator fruitAnimator;
    private bool fruitEnabled = true;


    void Start()
    {
        fruitAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(fruitEnabled && (collision.CompareTag("NinjaFrog") || collision.CompareTag("VirtualGuy")))
        {
            fruitEnabled = false;
            StartCoroutine(CollectFruit());
        }
    }


    private IEnumerator CollectFruit()
    {
        fruitAnimator.SetTrigger("fruitCollected");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
