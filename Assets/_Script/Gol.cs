using UnityEngine;

public class Gol : MonoBehaviour{
    public PosicionamentoBlocos posBlocos;
    
    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.GetComponent<Bola>().player1){
            //pontuação Player 1
            posBlocos.ResetEsquerda();
        }
        if (col.gameObject.GetComponent<Bola>().player2){
            //pontuação Player 2
            posBlocos.ResetDireita();
        }
    }
}
