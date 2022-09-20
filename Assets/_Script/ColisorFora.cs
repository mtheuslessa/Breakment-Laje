using System;
using UnityEngine;

public class ColisorFora : MonoBehaviour{
    private BoxCollider2D _collider2D;

    private void Awake(){
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Bola")){
            Bola bola = col.gameObject.GetComponent<Bola>();
            bola.Reset();
        }

        if (col.CompareTag("PowerUp")){
            Destroy(col.gameObject);
        }

        if (col.CompareTag("BolaPrefab")){
            Destroy(col.gameObject);
        }
    }
}
