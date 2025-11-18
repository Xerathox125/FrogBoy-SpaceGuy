using UnityEngine;

public class Pinchos : MonoBehaviour
{
    [SerializeField] DestroyCharacter destroyCharacter;
    private string tagToDestroy;
    private bool destruirAmbos;


    void Start()
    {
        destruirAmbos = false;
        tagToDestroy = destroyCharacter.ToString();

        if (tagToDestroy == DestroyCharacter.Ambos.ToString())
        {
            destruirAmbos = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (destruirAmbos == true || collision.gameObject.CompareTag(tagToDestroy))
        {
            Destroy(collision.gameObject);
        }
    }

    private enum DestroyCharacter
    {
        NinjaFrog,
        VirtualGuy,
        Ambos
    }

}
