using UnityEngine;

public class Gol : MonoBehaviour{
    public PosicionamentoBlocos posBlocos;

    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.gameObject.CompareTag("Bola")){
            if (col.gameObject.GetComponent<Bola>().player1){
                posBlocos.ResetEsquerda();
            }

            if (col.gameObject.GetComponent<Bola>().player2){
                posBlocos.ResetDireita();
            }
        }
    }
}
