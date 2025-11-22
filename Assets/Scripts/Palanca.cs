using UnityEngine;

public class Palanca : MonoBehaviour
{
    [SerializeField] Direccion direccion;
    private Vector3 inicio, destino;
    private HingeJoint2D HingeJoint2D;
    private float anguloActivacion;
    public GameObject platform;
    public float distancia = 0, suavizado = 2;    
    

    void Start()
    {
        HingeJoint2D = GetComponent<HingeJoint2D>();
        anguloActivacion = HingeJoint2D.limits.min + 40;
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

    void Update()
    {
        float anguloPalanca = HingeJoint2D.jointAngle;

        if (anguloPalanca >= anguloActivacion)
        {
            MovePlatform();
        }
        else if (anguloPalanca < anguloActivacion)
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
