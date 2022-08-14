using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PosicionamentoBlocos : MonoBehaviour{
    public GameObject[] blocosEsquerda;
    public GameObject[] blocosDireita;

    private bool[] blocosEsquerdaBool;
    private bool[] blocosDireitaBool;

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
}
