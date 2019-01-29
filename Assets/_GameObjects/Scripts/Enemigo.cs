using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int danyo;//Daño que provoca durante el ataque
    public int salud;//Salud del enemigo
    public float distanciaDeteccion;//A partir de cuando tengo a tiro al player

    private void OnCollisionEnter(Collision collision) {
        print(collision.gameObject.name);
    }

    public void QuitarSalud() {

    }
    public void Morir() {

    }
    public void RecibirDanyo() {

    }



}
