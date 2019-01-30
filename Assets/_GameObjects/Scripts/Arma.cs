using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float force = 100;
    public void Disparar() {
        GameObject proyectil = Instantiate(
            prefabProyectil, 
            spawnPoint.position, 
            spawnPoint.rotation);
        proyectil.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * force);
    }
}
