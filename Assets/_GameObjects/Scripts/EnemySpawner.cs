using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject prefabEnemigo;
    [SerializeField] int timeBetweenSpawn = 5;
    void Start()
    {
        InvokeRepeating("GenerarEnemigo", 0, timeBetweenSpawn);
    }
    private void GenerarEnemigo() {
        Instantiate(prefabEnemigo, transform);
    }
    
}
