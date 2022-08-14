using TMPro;
using UnityEngine;

public class Pontuacao : MonoBehaviour{
    private long pontuacaoP1 = 0;
    private long pontuacaoP2 = 0;

    public TextMeshProUGUI textoP1, textoP2;

    public void updateTextoP1(long pontuacao){
        pontuacaoP1 += pontuacao;
        textoP1.text = "" + pontuacaoP1;
    }
    
    public void updateTextoP2(long pontuacao){
        pontuacaoP2 += pontuacao;
        textoP2.text = "" + pontuacaoP2;
    }
}
