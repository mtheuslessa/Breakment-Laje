using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoPlataforma : MonoBehaviour{
    private Rigidbody2D rb;
    private bool slowDown;
    private float lastPressTime;
    private float doublePressTime = 0.3f;

    public float speed;
    public float anguloMaximoBola = 75f;
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        slowDown = false;
    }

    private void Update(){
        if (slowDown == true){
            var direcao = rb.velocity.x;
            
            if (direcao <= 0){
                rb.velocity = rb.velocity + new Vector2(0.2f, 0);
                if (rb.velocity.x >= 0){
                    rb.velocity = new Vector2(0, 0);
                    slowDown = false;
                }
            } else{
                rb.velocity = rb.velocity - new Vector2(0.2f, 0);
                if (rb.velocity.x <= 0){
                    rb.velocity = new Vector2(0, 0);
                    slowDown = false;
                }
            }
        }
    }

    public void PlataformMoviment (InputAction.CallbackContext context){
        Vector2 inputValue = context.ReadValue<Vector2>();
        if (context.performed){
            float timeSinceLastPress = Time.time - lastPressTime;
            
            if (timeSinceLastPress <= doublePressTime){
                rb.velocity = new Vector2((inputValue.x * speed * 2), rb.velocity.y);
            } else{
                rb.velocity = new Vector2((inputValue.x * speed), rb.velocity.y);
            }

            lastPressTime = Time.time;
            slowDown = false;
        }

        if (context.canceled) {
            slowDown = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        Bola bola = col.gameObject.GetComponent<Bola>();
        Rigidbody2D rbBola = bola.GetComponent<Rigidbody2D>();

        if (bola != null) {
            Vector3 posicaoBarra = transform.position;
            Vector2 pontoContato = col.GetContact(0).point;

            float offset = posicaoBarra.x - pontoContato.x;
            float largura = col.otherCollider.bounds.size.x / 2;

            float anguloAtual = Vector2.SignedAngle(Vector2.up, rbBola.velocity);
            float anguloQuique = (offset / largura) * anguloMaximoBola;
            float novoAngulo = Mathf.Clamp(anguloAtual + anguloQuique, -anguloMaximoBola, anguloMaximoBola);
            
            Quaternion rotacao = Quaternion.AngleAxis(novoAngulo, Vector3.forward);
            rbBola.velocity = rotacao * Vector2.up * rbBola.velocity.magnitude;
        }
    }
}
