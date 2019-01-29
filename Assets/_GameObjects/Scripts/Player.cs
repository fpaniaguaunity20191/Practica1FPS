using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Text txtVida;
    [SerializeField] int salud = 100;
    private const int SALUD_MAXIMA = 100;
    private GameObject arma;
    private bool esInmune;
    private bool estaVivo;

    private void Start() {
        txtVida.text = salud.ToString();
    }

    public bool IncrementarSalud(int incremento) {
        bool atope = true;
        if (salud < SALUD_MAXIMA) {
            salud = salud + incremento;//salud+=incremento
            salud = Mathf.Min(salud, SALUD_MAXIMA);
            txtVida.text = salud.ToString();
            atope = false;
        }
        return atope;
    }

    private void RecibirDanyo() {

    }
    private void Morir() {

    }
}
