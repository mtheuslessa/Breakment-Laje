using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovimentoBola : MonoBehaviour{
    private Rigidbody2D rb;
    private CircleCollider2D colisor;
    private bool rodando;
    
    public Transform barrinha;
    public float velocidade;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        colisor = GetComponent<CircleCollider2D>();
        
        rb.velocity = Vector2.one.normalized * velocidade;
        
        soltarBolinha();
    }

    private void Update() {
        if (!rodando) {
            transform.position = barrinha.position;
            colisor.enabled = false;
        } else {
            /*if (rb.velocity.x > 0f && rb.velocity.x != velocidade) {
                rb.velocity.Set(velocidade, rb.velocity.y);
            }
                
            if (rb.velocity.x < 0f && rb.velocity.x != -velocidade){
                rb.velocity.Set(-velocidade, rb.velocity.y);
            }
                
            if (rb.velocity.y > 0f && rb.velocity.y != velocidade) {
                rb.velocity.Set(velocidade, rb.velocity.y);
            }
                
            if (rb.velocity.y < 0f && rb.velocity.y != -velocidade) {
                rb.velocity.Set(-velocidade, rb.velocity.y);
            }*/
        }
    }

    public void soltarBolinha(){
        this.Wait(3f, () => {
            rodando = true;
            colisor.enabled = true;
            float x = Random.Range(-0.5f, 0.5f);
            Vector2 direcao = new Vector2(x, 1).normalized;
            rb.velocity = direcao * velocidade;
        });        
    }
    
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.name == "Plataforma Player 1"){
            float x = PosicaoColisao(transform.position, other.transform.position, other.collider.bounds.size.x);
            Vector2 direcao = new Vector2(x, 1).normalized;
            rb.velocity = direcao * velocidade;
        }else if (other.gameObject.name == "Plataforma Player 2"){
            float x = PosicaoColisao(transform.position, other.transform.position, other.collider.bounds.size.x);
            Vector2 direcao = new Vector2(x, -1).normalized;
            rb.velocity = direcao * velocidade;
        }
    }

    private float PosicaoColisao(Vector2 bolaPosicao, Vector2 barraPosicao, float barraTamanho){
        return (bolaPosicao.x - barraPosicao.x) / barraTamanho;
    }
}
