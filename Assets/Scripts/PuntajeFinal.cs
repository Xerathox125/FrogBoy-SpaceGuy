using UnityEngine;
using UnityEngine.UIElements;

public class PuntajeFinal : MonoBehaviour
{
    public static string rango;
    private Label lblRango;
    private VisualElement nivelCompletado;

    void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        lblRango = root.Q<Label>("lblRango");
        nivelCompletado = root.Q<VisualElement>("NivelCompletado");
    }

    void Update()
    {
        if (lblRango == null || nivelCompletado == null)
        {
            Debug.LogError("No se pudo acceder a los elementos de la UI");
        }
        else if (GameController.playersOnFlag == 2)
        {
            lblRango.text = rango;
            nivelCompletado.RemoveFromClassList("NivelCompletadoRight");
        }
    }
}
