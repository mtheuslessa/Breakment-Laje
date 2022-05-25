using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;


public class MovimentoBola : MonoBehaviour{
    private Rigidbody2D rb;

    public float velocidade;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void SoltarBolinha(InputAction.CallbackContext context){
        if (context.performed){
            rb.AddForce(new Vector2(Random.Range(-1, 1), (Random.Range(0f, 1f) * velocidade)));
        }
    }
}
