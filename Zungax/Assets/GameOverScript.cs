using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public int initialPrefabCount = 10;
    private int currentPrefabCount;
    private float timer = 120f;
    private bool gameOver = false;

    void Start()
    {
        currentPrefabCount = initialPrefabCount;
    }

    void Update()
    {
        // Si el juego ya terminó, no hacemos nada
        if (gameOver)
            return;

        // Restamos tiempo al temporizador
        timer -= Time.deltaTime;

        // Si el temporizador llega a cero, activamos el game over
        if (timer <= 0)
        {
            ActivateGameOver();
        }
    }

    void ActivateGameOver()
    {
        // Activamos el estado de game over
        gameOver = true;

        // Aquí puedes realizar cualquier acción relacionada con el game over, como cambiar de escena
        SceneManager.LoadScene("GameOverScene"); // Reemplaza "GameOverScene" con el nombre de tu escena de game over
    }

    public void ReducePrefabCount()
    {
        currentPrefabCount--;

        // Si la cantidad de prefabs llega a cero, activamos el game over
        if (currentPrefabCount <= 0)
        {
            ActivateGameOver();
        }
    }
}
