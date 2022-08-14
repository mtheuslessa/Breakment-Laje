using System;
using UnityEngine;

public class BlocoScript : MonoBehaviour {
    public int vidaAtual, vidaTotal;
    public bool imortal;
    public PosicionamentoBlocos posBlocos;
    public bool esquerda, direita;
    
    private GameObject gameManager;
    private Pontuacao pontuacao;
    private long pontosAzul = 100;
    private long pontosVerde = 250;
    private long pontosLaranja = 500;

    private void Awake(){
        gameManager = GameObject.Find("Game Controller");
        pontuacao = gameManager.GetComponent<Pontuacao>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        AtualizaVida();
    }

    public void AtualizaVida(){
        if (!imortal) {
            vidaAtual--;
            if (vidaAtual <= 0){
                if(esquerda){
                    posBlocos.BlocoEsquerdaQuebrado(gameObject);
                    atualizaPontosEsquerda();
                }
                if (direita){
                    posBlocos.BlocoDireitaQuebrado(gameObject);
                    atualizaPontosDireita();
                }
                vidaAtual = vidaTotal;
            }
        }
    }

    public void atualizaPontosEsquerda(){
        if (gameObject.CompareTag("Bloco Azul")){
            pontuacao.UpdateTextoP1(pontosAzul);
        }
        if (gameObject.CompareTag("Bloco Verde")){
            pontuacao.UpdateTextoP1(pontosVerde);
        }
        if (gameObject.CompareTag("Bloco Laranja")){
            pontuacao.UpdateTextoP1(pontosLaranja);
        }
    }
    public void atualizaPontosDireita(){
        if (gameObject.CompareTag("Bloco Azul")){
            pontuacao.UpdateTextoP2(pontosAzul);
        }
        if (gameObject.CompareTag("Bloco Verde")){
            pontuacao.UpdateTextoP2(pontosVerde);
        }
        if (gameObject.CompareTag("Bloco Laranja")){
            pontuacao.UpdateTextoP2(pontosLaranja);
        }
    }
}
