using UnityEngine;

public class DoubleButtons : MonoBehaviour
{
    [SerializeField] Direccion direccion;
    public GameObject platform;
    public float distancia = 0, suavizado = 2;
    public bool ambosNecesarios;

    private int buttonsPressed = 0;
    private Vector3 inicio, destino;

    public int ButtonsPressed { get => buttonsPressed; set => buttonsPressed = value; }

    void Start()
    {
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



    // Update is called once per frame
    void Update()
    {
        if (ambosNecesarios)
        {
            if(buttonsPressed == 2)
            {
                MovePlatform();
            }
            else if (buttonsPressed != 2)
            {
                ReturnPlatform();
            }
        }
        else if (!ambosNecesarios)
        {
            if (buttonsPressed != 0)
            {
                MovePlatform();
            }
            else if(buttonsPressed == 0)
            {
                ReturnPlatform();
            }                
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
