using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool gameRunning;
    public static int[] niveles = new int[] { 1, 0, 0 };
    public static int collectedFruits, playersOnFlag;
    public GameObject NinjaFrog, VirtualGuy;
    private int[,] puntajes;
    private int indiceNivel;

    void Start()
    {
        gameRunning = true;
        playersOnFlag = 0;

        puntajes = new int[,]
        {
            {30,40,6},
            {40,50,8},
            {60,75,12},
        };

        indiceNivel = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if(playersOnFlag == 2)
        {
            EndLevel();
        }

        if (NinjaFrog == null)
        {
            GameOver();
        }
        else if (VirtualGuy == null)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(indiceNivel);
        GameTimer.tiempo = 0;
    }

    private void EndLevel()
    {
        gameRunning = false;
        NinjaFrog.GetComponent<PlayerInput>().enabled = false;
        VirtualGuy.GetComponent<PlayerInput>().enabled = false;

        if (indiceNivel < niveles.Length)
        {
            niveles[indiceNivel] = 1;
        }

        Puntaje();
    }

    private void Puntaje()
    {
        float tiempo = GameTimer.tiempo;

        if (tiempo < puntajes[indiceNivel - 1, 0] && collectedFruits == puntajes[indiceNivel - 1, 2])
        {
            //Rango A
        }
        else if (tiempo < puntajes[indiceNivel - 1, 1] || collectedFruits == puntajes[indiceNivel - 1, 2])
        {
            //Rango B
        }
        else
        {
            //Rango C
        }

        StartCoroutine(CargarSiguienteNivel());
    }


    private IEnumerator CargarSiguienteNivel()
    {
        yield return new WaitForSeconds(3);

        if (indiceNivel < niveles.Length)
        {
            SceneManager.LoadScene(indiceNivel + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

        collectedFruits = 0;
        playersOnFlag = 0;
    }
}

