using UnityEngine;
using UnityEngine.UIElements;

public class GameTimer : MonoBehaviour
{
    private float minutos, segundos;
    public static float tiempo;
    private Label timer; 

    void Start()
    {
        tiempo = 0;

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        timer = root.Q<Label>("lblTimer");
    }

    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        tiempo += Time.deltaTime;

        minutos = Mathf.Floor(tiempo / 60);
        segundos = Mathf.Floor(tiempo % 60);

        if(timer == null)
        {
            Debug.Log("No se puede acceder al label");
        }
        else
        {
            timer.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }            

    }
}
