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
    public int armaActiva = 0;

    private void Start() {
        txtVida.text = salud.ToString();
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Disparar();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            armas[armaActiva].Reload();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            CambiarArma(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            CambiarArma(1);
        }
    }
    private void CambiarArma(int armaAActivar)
    {
        //Desactivamos todas las armas
        for(int i = 0; i < armas.Length; i++)
        {
            armas[i].gameObject.SetActive(false);
        }
        armas[armaAActivar].gameObject.SetActive(true);
        armaActiva = armaAActivar;
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
        armas[armaActiva].ApretarGatillo();
    }
}
