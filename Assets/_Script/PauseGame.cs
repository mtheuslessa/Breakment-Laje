using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour{

    private bool pauseOrResume = false;
    
    public void Pause(){
        if (pauseOrResume){
            Time.timeScale = 0;
            pauseOrResume = !pauseOrResume;
        } else{
            Time.timeScale = 1;
            pauseOrResume = !pauseOrResume;
        }
    }
}
