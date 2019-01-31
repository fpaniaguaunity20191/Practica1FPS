using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoListo : EnemigoMovil
{
    private Transform transformPlayer;
    private void Start() {
        transformPlayer = GameObject.Find("Player").transform;
        base.Start();
    }
    private void Update() {
        if (EstaADistanciaDeAtaque()) { //A por él
            transform.LookAt(transformPlayer);
        }
        base.Update();
    }
    private bool EstaADistanciaDeAtaque() {
        bool estaADistancia = false;
        if (Vector3.Distance(
            transform.position,
            transformPlayer.position) < distanciaDeteccion) {
            estaADistancia = true;
        }
        return estaADistancia;
    }
}
