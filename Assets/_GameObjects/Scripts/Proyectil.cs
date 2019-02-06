using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] int danyo = 1;
    [SerializeField] GameObject prefabImpacto;
    [SerializeField] float tiempoParaDestruccion = 3;
    private void Start()
    {
        Destroy(gameObject, tiempoParaDestruccion);
    }

    private void OnCollisionEnter(Collision collision) {
        //collision.gameObject me proporciona el objeto con el que ha colisionado
        if (collision.gameObject.CompareTag("Enemy")) {
            //Es un enemigo
            collision.gameObject.GetComponent<Enemigo>().RecibirDanyo(danyo);
            Instantiate(prefabImpacto, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
