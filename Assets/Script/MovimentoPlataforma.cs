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

    public void PlataformMoviment (InputAction.CallbackContext context){
        Vector2 inputValue = context.ReadValue<Vector2>();
        if (context.performed){
            rb.velocity = new Vector2((inputValue.x * speed), rb.velocity.y);
        }

        if (context.canceled){
            slowDownPlataform(context.ReadValue<Vector2>().x);
        }
    }

    public void SoltarPoder(InputAction.CallbackContext context){
        if(context.performed)
            Debug.Log("Poder" + context.phase);
    }

    public void slowDownPlataform(float direction){
        if (direction == -1){
            rb.velocity = new Vector2(rb.velocity.x - 1f, rb.velocity.y);
        }else{
            rb.velocity = new Vector2(0, 0);
        }


    }
}
