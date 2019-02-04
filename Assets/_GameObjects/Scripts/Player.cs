using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Text txtVida;
    [SerializeField] int salud = 100;
    private const int SALUD_MAXIMA = 100;
    [SerializeField] Arma[] armas;
    private bool esInmune;
    private bool estaVivo;

    private void Start() {
        txtVida.text = salud.ToString();
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Disparar();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            armas[0].Reload();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            armas[0].enabled = true;
            armas[1].enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            armas[0].enabled = false;
            armas[1].enabled = true;
        }
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
    public void RecibirDanyo(int danyo) {
        salud = salud - danyo;
        salud = Mathf.Max(salud, 0);
        txtVida.text = salud.ToString();
    }
    private void Morir() {

    }
    private void Disparar() {
        armas[0].ApretarGatillo();
    }
}
