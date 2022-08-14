using UnityEngine;

public class BlocoScript : MonoBehaviour {
    public int vidaAtual, vidaTotal;
    public bool imortal;
    public PosicionamentoBlocos posBlocos;
    public bool esquerda, direita;

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
}
