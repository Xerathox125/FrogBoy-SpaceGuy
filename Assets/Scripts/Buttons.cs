using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] Direccion direccion;
    private Animator btnSpriteAnimator;
    private bool btnPressed;
    private Vector3 inicio, destino;
    public GameObject platform;
    public float distancia = 0, suavizado = 2;


    void Start()
    {
        btnSpriteAnimator = GetComponentInChildren<Animator>();
        inicio = platform.transform.position;

        switch (direccion)
        {
            case Direccion.Horizontal:
                destino = new Vector3(inicio.x + distancia, inicio.y, inicio.z);
                break;
            case Direccion.Vertical:
                destino = new Vector3(inicio.x, inicio.y + distancia, inicio.z);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        btnPressed = true;
        btnSpriteAnimator.SetBool("btnPressed", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        btnPressed = false;
        btnSpriteAnimator.SetBool("btnPressed", false);
    }

    void Update()
    {        
        if (btnPressed && GameController.gameRunning == true)
        {
            MovePlatform();
        }
        else if(!btnPressed && GameController.gameRunning == true)
        {
            ReturnPlatform();
        }    
    }


    private void MovePlatform()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, destino, suavizado * Time.deltaTime);
    }

    private void ReturnPlatform()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, inicio, suavizado * Time.deltaTime);
    }

    private enum Direccion
    {
        Horizontal,
        Vertical
    }
}
