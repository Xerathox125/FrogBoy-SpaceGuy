using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuInicioScript : MonoBehaviour
{
    private Button btnJugar, btnRegresoMenu, btnLevel1, btnLevel2, btnLevel3;
    private VisualElement ventanaNiveles;

    void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        btnJugar = root.Q<Button>("btnJugar");
        btnRegresoMenu = root.Q<Button>("btnRegresoMenu");
        btnLevel1 = root.Q<Button>("btnLevel1");
        btnLevel2 = root.Q<Button>("btnLevel2");
        btnLevel3 = root.Q<Button>("btnLevel3");
        ventanaNiveles = root.Q<VisualElement>("ventanaNiveles");

    }

    private void OnEnable()
    {
        if(btnJugar == null || btnRegresoMenu == null || btnLevel1 == null || btnLevel2 == null || btnLevel3 == null || ventanaNiveles == null)
        {
            Debug.Log("No se pudo acceder a los elementos de la UI");
        }
        else
        {
            btnJugar.clicked += OnBtnJugar;
            btnRegresoMenu.clicked += OnBtnRegresoMenu;
            btnLevel1.clicked += OnBtnLevel1;
            btnLevel2.clicked += OnBtnLevel2;
            btnLevel3.clicked += OnBtnLevel3;
        }
    }


    private void OnDisable()
    {
        if (btnJugar == null || btnRegresoMenu == null || btnLevel1 == null || btnLevel2 == null || btnLevel3 == null || ventanaNiveles == null)
        {
            Debug.Log("No se pudo acceder a los elementos de la UI");
        }
        else
        {
            btnJugar.clicked -= OnBtnJugar;
            btnRegresoMenu.clicked -= OnBtnRegresoMenu;
            btnLevel1.clicked -= OnBtnLevel1;
            btnLevel2.clicked -= OnBtnLevel2;
            btnLevel3.clicked -= OnBtnLevel3;
        }
    }

    private void OnBtnJugar()
    {
        ventanaNiveles.RemoveFromClassList("ventanaNivelesRight");
    }
    private void OnBtnRegresoMenu()
    {
        ventanaNiveles.AddToClassList("ventanaNivelesRight");
    }

    private void OnBtnLevel1()
    {
        SceneManager.LoadScene(1);
    }
    private void OnBtnLevel2()
    {
        SceneManager.LoadScene(2);
    }

    private void OnBtnLevel3()
    {
        SceneManager.LoadScene(3);
    }


}
