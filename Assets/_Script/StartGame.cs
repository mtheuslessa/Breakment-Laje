using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour{ 
    private void Update(){
       if (Gamepad.all[0].startButton.isPressed || Gamepad.all[1].startButton.isPressed){
           SceneManager.LoadScene("Arena");
       }
    }
}
