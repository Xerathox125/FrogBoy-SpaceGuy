using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuPausa : MonoBehaviour
{
    private Button btnPausa, btnContinuar, btnInicio;
    private VisualElement menuPausa;


    void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        btnPausa = root.Q<Button>("btnPausa");
        btnContinuar = root.Q<Button>("btnContinuar");
        btnInicio = root.Q<Button>("btnInicio");
        menuPausa = root.Q<VisualElement>("MenuPausa");
    }

    private void OnEnable()
    {
        if(btnPausa == null || btnContinuar == null || btnInicio == null || menuPausa == null)
        {
            Debug.Log("No se puede acceder a los elementos de la UI");
        }
        else
        {
            btnPausa.clicked += OnPausaButton;
            btnContinuar.clicked += OnContinuarButton;
            btnInicio.clicked += OnInicioButton;
        }        
    }

    private void OnDisable()
    {
        if (btnPausa == null || btnContinuar == null || btnInicio == null || menuPausa == null)
        {
            Debug.Log("No se puede acceder a los elementos de la UI");
        }
        else
        {
            btnPausa.clicked -= OnPausaButton;
            btnContinuar.clicked -= OnContinuarButton;
            btnInicio.clicked -= OnInicioButton;
        }
    }


    private void OnPausaButton()
    {
        GameController.gameRunning = false;
        menuPausa.RemoveFromClassList("PausaDown");
    }

    private void OnContinuarButton()
    {
        GameController.gameRunning = true;
        menuPausa.AddToClassList("PausaDown");
    }

    private void OnInicioButton()
    {
        SceneManager.LoadScene(0);
    }
}
