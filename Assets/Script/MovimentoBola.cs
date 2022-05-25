using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class MovimentoBola : MonoBehaviour{
    private Rigidbody2D rb;

    public float velocidade;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        //if (Input.GetMouseButton(0)){
        //    rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f)) * velocidade);
        //}
    }
}
