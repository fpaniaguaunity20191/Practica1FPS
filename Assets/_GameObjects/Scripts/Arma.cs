using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    private AudioSource audioSource;
    public enum Estado { Disponible, Descargada, Recargando, Disparando };
    public Estado estado = Estado.Disponible;
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float cadencia;//Tiempo entre disparo
    [SerializeField] int capacidadCargador;
    [SerializeField] float force = 100;
    [SerializeField] int numeroCargadores;
    [SerializeField] float tiempoRecarga;
    [SerializeField] int municionCargador;//Municion disponible en el cargador
    [SerializeField] AudioClip acDisparo;
    [SerializeField] AudioClip acGatillazo;
    [SerializeField] AudioClip acRecarga;
    [SerializeField] AudioClip acCambioArma;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void ApretarGatillo() {
        if (estado == Estado.Disponible) {
            Disparar();
        } else if (estado == Estado.Descargada) {
            audioSource.PlayOneShot(acGatillazo);
        }
    }

    public void Reload() {
        if (estado != Estado.Recargando 
                && numeroCargadores>0 
                && municionCargador<capacidadCargador) {
            estado = Estado.Recargando;
            numeroCargadores--;
            municionCargador = capacidadCargador;
            audioSource.PlayOneShot(acRecarga);
            Invoke("ActivarArma", tiempoRecarga);
        }
    }

    private void Disparar() {
        GameObject proyectil = Instantiate(
        prefabProyectil,
        spawnPoint.position,
        spawnPoint.rotation);
        proyectil.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * force);
        audioSource.PlayOneShot(acDisparo);
        municionCargador--;
        if (municionCargador == 0) {
            estado = Estado.Descargada;
        } else {
            estado = Estado.Disparando;
            Invoke("ActivarArma", cadencia);
        }
    }

    private void ActivarArma() {
        this.estado = Estado.Disponible;
    }

    public void AgregarCargador() {
        numeroCargadores++;
    }
}
