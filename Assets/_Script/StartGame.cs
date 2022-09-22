using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour{ 
    private void Update(){
       if (Input.GetKeyDown(KeyCode.Joystick1Button9)){
           Debug.Log("Teste");
           SceneManager.LoadScene("Arena");
       }
    }
}
