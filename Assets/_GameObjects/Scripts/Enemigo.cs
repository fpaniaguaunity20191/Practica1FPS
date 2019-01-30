﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
    public int danyo;//Daño que provoca durante el ataque
    public int salud;//Salud del enemigo
    public float distanciaDeteccion;//A partir de cuando tengo a tiro al player
    public GameObject prefabExplosion; //Prefab de la explosión

    private void OnCollisionEnter(Collision collision) {
        /*
         * 1. Saber si ha colisionado con el player 
         * 2. si ha colisionado con el player -> hacer daño al player
         * 3. Generar un sonido de explosión
         * 4. Generar un sistema de partículas de explosión
         * 5. Destruir el gameobject
         */
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().RecibirDanyo(danyo);
            Morir();
        }
    }

    public void QuitarSalud() {

    }
    public void Morir() {
        Instantiate(prefabExplosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    public void RecibirDanyo() {

    }



}
