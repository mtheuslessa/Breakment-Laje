using TMPro;
using UnityEngine;

public class Pontuacao : MonoBehaviour{
    private long pontuacaoP1 = 0;
    private long pontuacaoP2 = 0;

    public TextMeshProUGUI textoP1, textoP2;

    public void UpdateTextoP1(long pontuacao){
        pontuacaoP1 += pontuacao;
        textoP1.text = "" + pontuacaoP1;
    }
    
    public void UpdateTextoP2(long pontuacao){
        pontuacaoP2 += pontuacao;
        textoP2.text = "" + pontuacaoP2;
    }

    public void ResetarPontos(){
        pontuacaoP1 = 0;
        pontuacaoP2 = 0;
        textoP1.text = "" + pontuacaoP1;
        textoP2.text = "" + pontuacaoP2;
    }
}
