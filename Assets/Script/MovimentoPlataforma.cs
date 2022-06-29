using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoPlataforma : MonoBehaviour{
    private Rigidbody2D rb;
    private bool slowDown;
    private float lastPressTime;
    private float doublePressTime = 0.3f;

    public float speed;
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        slowDown = false;
    }

    private void Update(){
        if (slowDown == true){
            var direcao = rb.velocity.x;
            
            if (direcao <= 0){
                rb.velocity = rb.velocity + new Vector2(0.2f, 0);
                if (rb.velocity.x >= 0){
                    rb.velocity = new Vector2(0, 0);
                    slowDown = false;
                }
            } else{
                rb.velocity = rb.velocity - new Vector2(0.2f, 0);
                if (rb.velocity.x <= 0){
                    rb.velocity = new Vector2(0, 0);
                    slowDown = false;
                }
            }
        }
    }

    public void PlataformMoviment (InputAction.CallbackContext context){
        Vector2 inputValue = context.ReadValue<Vector2>();
        if (context.performed){
            float timeSinceLastPress = Time.time - lastPressTime;
            
            if (timeSinceLastPress <= doublePressTime){
                rb.velocity = new Vector2((inputValue.x * speed * 2), rb.velocity.y);
            } else{
                rb.velocity = new Vector2((inputValue.x * speed), rb.velocity.y);
            }

            lastPressTime = Time.time;
            slowDown = false;
        }

        if (context.canceled) {
            slowDown = true;
        }
    }

    public void SoltarPoder(InputAction.CallbackContext context){
        if(context.performed)
            Debug.Log("Poder" + context.phase);
    }
}
