using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour
{
    [SerializeField] int danyo;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().RecibirDanyo(danyo);
            Destruir();
        }
    }
    private void Destruir() {
        Destroy(this.gameObject);
    }
}
