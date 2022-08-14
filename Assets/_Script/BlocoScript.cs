using UnityEngine;

public class BlocoScript : MonoBehaviour {
    public int vidaAtual, vidaTotal;
    public bool imortal;
    public PosicionamentoBlocos posBlocos;
    public bool esquerda, direita;
    public Pontuacao pontuacao;
    
    private long pontosAzul = 100;
    private long pontosVerde = 250;
    private long pontosLaranja = 500;

    private void OnCollisionEnter2D(Collision2D other) {
        AtualizaVida();
    }

    public void AtualizaVida(){
        if (!imortal) {
            vidaAtual--;
            if (vidaAtual <= 0){
                if(esquerda)
                    posBlocos.BlocoEsquerdaQuebrado(gameObject);
                    
                if(direita)
                    posBlocos.BlocoDireitaQuebrado(gameObject);
                vidaAtual = vidaTotal;
            }
        }
    }

    public void atualizaPontosEsquerda(Collision2D other){
        
        
        
        /*if (other.gameObject.CompareTag("Bloco Azul")){
            if(player1)
                pontuacao.updateTextoP1(pontosAzul);
            if(player2)
                pontuacao.updateTextoP2(pontosAzul);
        }
        if (other.gameObject.CompareTag("Bloco Verde")){
            if(player1)
                pontuacao.updateTextoP1(pontosVerde);
            if(player2)
                pontuacao.updateTextoP2(pontosVerde);
        }
        if (other.gameObject.CompareTag("Bloco Laranja")){
            if(player1)
                pontuacao.updateTextoP1(pontosLaranja);
            if(player2)
                pontuacao.updateTextoP2(pontosLaranja);
        }*/
        
        
    }
}
