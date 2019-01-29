using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaDeSalud : MonoBehaviour
{
    public int cantidadSalud = 8;
    [SerializeField] private float velocidadGiro = 100f;
    
    public void Update()
    {
        Rotar();
    }
    private void Rotar() {
        transform.Rotate(new Vector3(0, Time.deltaTime * velocidadGiro, 0));
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            bool atope = other.gameObject.GetComponent<Player>().IncrementarSalud(cantidadSalud);
            if (atope == false) {
                Destroy(this.gameObject);
            }
        }
    }

}
