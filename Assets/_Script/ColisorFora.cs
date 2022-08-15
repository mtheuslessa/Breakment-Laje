using System;
using UnityEngine;

public class ColisorFora : MonoBehaviour{
    private BoxCollider2D _collider2D;

    private void Awake(){
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col){
        Bola bola = col.gameObject.GetComponent<Bola>();
        bola.Reset();
    }
}
