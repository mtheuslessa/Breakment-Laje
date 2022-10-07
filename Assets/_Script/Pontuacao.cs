using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pontuacao : MonoBehaviour{
    private long pontuacaoP1 = 0;
    private long pontuacaoP2 = 0;

    public AudioSource musicaFinal, musicaGame;

    public TextMeshProUGUI textoP1, textoP2, textoVencedor, textoPontuacao;

    public void UpdateTextoP1(long pontuacao){
        pontuacaoP1 += pontuacao;
        textoP1.text = "" + pontuacaoP1.ToString("N0");
    }
    
    public void UpdateTextoP2(long pontuacao){
        pontuacaoP2 += pontuacao;
        textoP2.text = "" + pontuacaoP2.ToString("N0");
    }

    public void ResetarPontos(){
        pontuacaoP1 = 0;
        pontuacaoP2 = 0;
        textoP1.text = "" + pontuacaoP1.ToString("N0");
        textoP2.text = "" + pontuacaoP2.ToString("N0");
        musicaGame.Stop();
        musicaFinal.Play();
        Invoke(nameof(ResetScene), 10f);
    }

    public void MaiorPontuacao(){
        textoVencedor.transform.parent.gameObject.SetActive(true);
        if (pontuacaoP1 > pontuacaoP2){
            textoVencedor.text = "Player 01";
            textoPontuacao.text = "Pontos: " + pontuacaoP1.ToString("N0");
        }else if(pontuacaoP1 < pontuacaoP2){
            textoVencedor.text = "Player 02";
            textoPontuacao.text = "Pontos: " + pontuacaoP2.ToString("N0");
        }else{
            textoVencedor.text = "Empate";
        }
    }

    public void ResetScene(){
        SceneManager.LoadScene("Menu");
    }
}
