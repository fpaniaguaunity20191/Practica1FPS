using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerRandom : MonoBehaviour
{
    [SerializeField] GameObject[] prefabsEnemigo;
    [SerializeField] int timeBetweenSpawn = 5;
    private void Start()
    {
        InvokeRepeating("GenerarEnemigo", 0, timeBetweenSpawn);
    }
    private void GenerarEnemigo()
    {
        int numeroEnemigos = prefabsEnemigo.Length;
        int indiceEnemigoAleatorio = Random.Range(0, numeroEnemigos);
        Instantiate(prefabsEnemigo[indiceEnemigoAleatorio], transform);
    }
    
    /*
    private void GenerarEnemigo() {
        float tipoEnemigo = Random.Range(0f, 1f);
        if (tipoEnemigo < 0.5f)
        {
            Instantiate(prefabsEnemigo[1], transform);
        } else
        {
            Instantiate(prefabsEnemigo[0], transform);
        }
    }
    */
    
}
