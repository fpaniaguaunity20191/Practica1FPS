using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFijo : Enemigo
{
    public GameObject prefabBalas;
    public Transform spawnPoint;
    public Transform ejeRotacion;
    public float fuerzaDisparo;
    public float cadenciaDisparo;
    private float factorCorrectionAngulo = -5;

    enum Estado { Idle, Attack, Reload };
    private Estado estado = Estado.Idle;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            estado = Estado.Attack;
            InvokeRepeating("Disparar", 0, cadenciaDisparo);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            estado = Estado.Idle;
            CancelInvoke();
        }
    }
    private void Update() {
        if (estado == Estado.Attack) {
            ejeRotacion.LookAt(transformPlayer);
            ejeRotacion.transform.Rotate(new Vector3(factorCorrectionAngulo, 0, 0));
        }
    }
    private void Disparar() {
        GameObject bala = Instantiate(
            prefabBalas,
            spawnPoint.position,
            spawnPoint.rotation);
        bala.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * fuerzaDisparo);
    }



}
