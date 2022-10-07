using System;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private SoundManager sounds;
    private ParticleController particleController;

    public SpawnPowerUp spawnPowerUp;

    private void Awake(){
        gameManager = GameObject.Find("Game Controller");
        pontuacao = gameManager.GetComponent<Pontuacao>();
        sounds = gameManager.GetComponent<SoundManager>();
        particleController = gameManager.GetComponent<ParticleController>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        AtualizaVida();
    }

    public void AtualizaVida(){
        if (!imortal){
            vidaAtual--;
            if (vidaAtual <= 0){
                ParticleEmitter();
                sounds.PlayBlocoQuebrando();
                SpawnPowerup();
                if(esquerda){
                    posBlocos.BlocoEsquerdaQuebrado(gameObject);
                    atualizaPontosEsquerda();
                }
                if (direita){
                    posBlocos.BlocoDireitaQuebrado(gameObject);
                    atualizaPontosDireita();
                }
                vidaAtual = vidaTotal;
            } else{
                sounds.PlayBolinhaQuicando();
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

    public void SpawnPowerup(){
        if(esquerda){
            if (gameObject.CompareTag("Bloco Azul")){
                spawnPowerUp.SpawnEsqLowLife(transform.position);
            }
            if (gameObject.CompareTag("Bloco Verde")){
                spawnPowerUp.SpawnEsqMidLife(transform.position);
            }
            if (gameObject.CompareTag("Bloco Laranja")){
                spawnPowerUp.SpawnEsqHighLife(transform.position);
            }
        }

        if (direita){
            if (gameObject.CompareTag("Bloco Azul")){
                spawnPowerUp.SpawnDirLowLife(transform.position);
            }
            if (gameObject.CompareTag("Bloco Verde")){
                spawnPowerUp.SpawnDirMidLife(transform.position);
            }
            if (gameObject.CompareTag("Bloco Laranja")){
                spawnPowerUp.SpawnDirHighLife(transform.position);
            }
        }
    }

    public void ParticleEmitter(){
        if (gameObject.CompareTag("Bloco Azul")){
            particleController.InstantiateParticleAzul(transform.position);
        }
        if (gameObject.CompareTag("Bloco Verde")){
            particleController.InstantiateParticleVerde(transform.position);
        }
        if (gameObject.CompareTag("Bloco Laranja")){
            particleController.InstantiateParticleLaranja(transform.position);
        }
    }
}
