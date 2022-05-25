using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoPlataforma : MonoBehaviour{
    private Rigidbody2D rb;

    public float speed;
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate(){
        
    }

    public void PlataformMoviment (InputAction.CallbackContext context){
        if (context.performed){
            Vector2 inputValue = context.ReadValue<Vector2>();
            rb.velocity = Vector2.right * speed * inputValue * Time.deltaTime;
        }
    }

    public void SoltarPoder(InputAction.CallbackContext context){
        if(context.performed)
            Debug.Log("Poder" + context.phase);
    }
}
