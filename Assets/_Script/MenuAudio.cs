using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour{
    public AudioSource menuMaster, menuLoop;

    private void Update(){
        if (!menuMaster.isPlaying && !menuLoop.isPlaying){
            menuLoop.Play();
        }
    }
}
