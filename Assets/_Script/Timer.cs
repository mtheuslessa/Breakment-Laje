using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour{
    public TextMeshProUGUI timerText;
    public PosicionamentoBlocos posBlocos;
    
    private float tempoTotal = 300f;
    private float minutos, segundos;
    private bool resetar = true;

    private void Update(){
        if (tempoTotal > 0){
            tempoTotal -= Time.deltaTime;
            resetar = true;
        } else{
            tempoTotal = 0;
        }

        if (tempoTotal == 0 && resetar){
            posBlocos.ResetaAmbos();
            resetar = false;
            tempoTotal = 300f;
        }

        MonstarTempo();
    }

    private void MonstarTempo(){
        if (tempoTotal < 0){
            tempoTotal = 0;
        }
        minutos = Mathf.FloorToInt(tempoTotal / 60);
        segundos = Mathf.FloorToInt(tempoTotal % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
