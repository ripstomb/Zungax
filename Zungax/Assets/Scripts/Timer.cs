using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject objectToSurround; // El objeto alrededor del cual se generan los prefabs
    public GameObject prefabToSpawn; // El prefab que deseas instanciar
    public int numberOfPrefabs = 5; // Número de prefabs a instanciar
    public float spawnRadius = 125f; // Radio en el que se generan los prefabs

    private int prefabsRemaining; // Número de prefabs restantes
    private bool gameOver = false; // Variable para controlar el estado del juego

    void Start()
    {
        StartCoroutine(SpawnPrefabsRoutine());
        prefabsRemaining = numberOfPrefabs; // Inicializamos el contador de prefabs restantes
        SpawnPrefabs(); // Llamamos a la función para instanciar los prefabs
    }
    IEnumerator SpawnPrefabsRoutine()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(5f); // Espera 5 segundos antes de generar el siguiente prefab

            SpawnPrefabs(); // Llama a la función para instanciar un prefab
        }
    }

    public void SpawnPrefabs()
    {
        if (objectToSurround == null)
        {
            Debug.LogError("Object to surround not assigned!");
            return;
        }

        for (int i = 0; i < numberOfPrefabs; i++)
        {
            // Genera una posición aleatoria dentro del radio
            Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;

            // Aplica la posición alrededor del objeto
            Vector3 spawnPosition = objectToSurround.transform.position + randomPosition;

            // Asegúrate de que la posición generada esté en el plano del suelo (opcional)
            spawnPosition.y = 0f;

            // Instancia el prefab en la posición generada
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    public void PrefabDestroyed()
    {
        prefabsRemaining--; // Disminuimos la cantidad de prefabs restantes

        // Verificamos si se han destruido todos los prefabs
        if (prefabsRemaining <= 0 && !gameOver)
        {
            ActivateGameOver(); // Llamamos a la función para activar el game over
        }
    }

    void ActivateGameOver()
    {
        gameOver = true; // Marcamos que el juego ha terminado

        // Cargar la escena de Game Over
        SceneManager.LoadScene("GameOverScene"); // Reemplaza "GameOverScene" con el nombre de tu escena de Game Over
    }
}

