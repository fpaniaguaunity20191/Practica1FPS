using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] int danyo = 1;

    private void OnCollisionEnter(Collision collision) {
        //collision.gameObject me proporciona el objeto con el que ha colisionado
        if (collision.gameObject.CompareTag("Enemy")) {
            //Es un enemigo
            collision.gameObject.GetComponent<Enemigo>().RecibirDanyo(danyo);
        }
    }
}
