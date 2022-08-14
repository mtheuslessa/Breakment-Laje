using System;
using UnityEngine.InputSystem;
using UnityEngine;

public class Barra : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector2 direcao;

    public float velocidade = 30f;
    public float anguloMaximoBola = 45f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void PlataformMoviment (InputAction.CallbackContext context){
        Vector2 inputValue = context.ReadValue<Vector2>();
        if (context.performed){
            if (inputValue.x < 0){
                direcao = Vector2.up;
            } else{
                direcao = Vector2.down;
            }
        }

        if (context.canceled){
            direcao = Vector2.zero;
        }
    }

    private void FixedUpdate(){
        if (direcao != Vector2.zero){
            rb.AddForce(direcao * velocidade);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col) {
        Bola bola = col.gameObject.GetComponent<Bola>();

        if (bola != null) {
            Rigidbody2D rbBola = bola.GetComponent<Rigidbody2D>();
            Vector3 posicaoBarra = transform.position;
            Vector2 pontoContato = col.GetContact(0).point;

            float offset = posicaoBarra.y - pontoContato.y;
            float largura = col.otherCollider.bounds.size.y / 2;

            float anguloAtual = Vector2.SignedAngle(Vector2.right, rbBola.velocity);
            float anguloQuique = -((offset / largura) * anguloMaximoBola);
            float novoAngulo = Mathf.Clamp(anguloAtual + anguloQuique, -anguloMaximoBola, anguloMaximoBola);
            
            Quaternion rotacao = Quaternion.AngleAxis(novoAngulo, Vector3.forward);
            rbBola.velocity = rotacao * Vector2.right * rbBola.velocity.magnitude;
        }
    }
}
