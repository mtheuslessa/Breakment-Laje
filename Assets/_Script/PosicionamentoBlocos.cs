using UnityEngine;

public class PosicionamentoBlocos : MonoBehaviour{
    public GameObject[] blocosEsquerda;
    public GameObject[] blocosDireita;
    public Bola bolaP1, bolaP2;

    private bool[] blocosEsquerdaBool;
    private bool[] blocosDireitaBool;

    public Pontuacao pontuacaoBlocos;
    
    private long pontosAzul = 100;
    private long pontosVerde = 250;
    private long pontosLaranja = 500;
    private long pontosReset = 0;

    private void Awake(){
        blocosEsquerdaBool = new bool[blocosEsquerda.Length];
        blocosDireitaBool = new bool[blocosDireita.Length];

        for (int i = 0; i < blocosEsquerdaBool.Length; i++){
            blocosEsquerdaBool[i] = true;
            blocosDireitaBool[i] = true;
        }
    }

    public void BlocoEsquerdaQuebrado(GameObject bloco){
        for (int i = 0; i < blocosEsquerda.Length; i++){
            if (blocosEsquerda[i] == bloco){
                blocosEsquerda[i].SetActive(false);
                blocosEsquerdaBool[i] = false;
                if (!blocosDireitaBool[i]){
                    blocosDireita[i].SetActive(true);
                    blocosDireitaBool[i] = true;
                }
            }
        }
    }
    
    public void BlocoDireitaQuebrado(GameObject bloco){
        for (int i = 0; i < blocosDireita.Length; i++){
            if (blocosDireita[i] == bloco){
                blocosDireita[i].SetActive(false);
                blocosDireitaBool[i] = false;
                if (!blocosEsquerdaBool[i]){
                    blocosEsquerda[i].SetActive(true);
                    blocosEsquerdaBool[i] = true;
                }
            }
        }
    }

    public void ResetEsquerda(){
        bolaP1.Reset();
        for (int i = 0; i < blocosEsquerda.Length; i++){
            if (!blocosEsquerdaBool[i]){
                if (blocosEsquerda[i].CompareTag("Bloco Azul")){
                    pontosReset += pontosAzul;
                }
                if (blocosEsquerda[i].CompareTag("Bloco Verde")){
                    pontosReset += pontosVerde;
                }
                if (blocosEsquerda[i].CompareTag("Bloco Laranja")){
                    pontosReset += pontosLaranja;
                }
            }
            blocosEsquerda[i].SetActive(true);
            blocosEsquerdaBool[i] = true;
        }

        pontuacaoBlocos.UpdateTextoP1(pontosReset);
        pontosReset = 0;
    }
    
    public void ResetDireita(){
        bolaP2.Reset();
        for (int i = 0; i < blocosDireita.Length; i++){
            if (!blocosDireitaBool[i]){
                if (blocosDireita[i].CompareTag("Bloco Azul")){
                    pontosReset += pontosAzul;
                }
                if (blocosDireita[i].CompareTag("Bloco Verde")){
                    pontosReset += pontosVerde;
                }
                if (blocosDireita[i].CompareTag("Bloco Laranja")){
                    pontosReset += pontosLaranja;
                }
            }
            blocosDireita[i].SetActive(true);
            blocosDireitaBool[i] = true;
        }

        pontuacaoBlocos.UpdateTextoP2(pontosReset);
        pontosReset = 0;
    }

    public void ResetaAmbos(){
        for (int i = 0; i < blocosDireita.Length; i++){
            blocosDireita[i].SetActive(true);
            blocosDireitaBool[i] = true;
            
            blocosEsquerda[i].SetActive(true);
            blocosEsquerdaBool[i] = true;
        }
        
        pontuacaoBlocos.ResetarPontos();
        bolaP1.Reset();
        bolaP2.Reset();
    }
}
