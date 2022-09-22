using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pontuacao : MonoBehaviour{
    private long pontuacaoP1 = 0;
    private long pontuacaoP2 = 0;

    public TextMeshProUGUI textoP1, textoP2, textoVencedor;
    //public GameObject imagemTexto;

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
        Invoke(nameof(ResetScene), 5f);
    }

    public void MaiorPontuacao(){
        textoVencedor.transform.parent.gameObject.SetActive(true);
        if (pontuacaoP1 > pontuacaoP2){
            textoVencedor.text = "Player 01";
        }else if(pontuacaoP1 < pontuacaoP2){
            textoVencedor.text = "Player 02";
        }else{
            textoVencedor.text = "Empate";
        }
    }

    public void ResetScene(){
        SceneManager.LoadScene("Menu");
    }
}
