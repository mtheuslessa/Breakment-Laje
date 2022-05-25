using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoPlataforma : MonoBehaviour{
    private Rigidbody2D rb;
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate(){
        
    }

    public void MovimentoBolinha(InputAction.CallbackContext context){
        //cb.action.
    }

    public void SoltarPoder(InputAction.CallbackContext context){
        if(context.performed)
            Debug.Log("Poder" + context.phase);
    }
}
