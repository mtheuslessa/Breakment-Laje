using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour{
    public bool speed, slow, multi;
    public bool ladoEsquerdo, ladoDireito;

    private int _velocidade = 2;
    private Rigidbody2D _rb;

    private void Update(){
        if(ladoEsquerdo)
            transform.Translate(Vector3.left * (_velocidade * Time.deltaTime));
        if(ladoDireito)
            transform.Translate(Vector3.right * (_velocidade * Time.deltaTime));
    }
}
