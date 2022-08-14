using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoScript : MonoBehaviour {
    public int vida;
    public bool imortal;

    private void OnCollisionEnter2D(Collision2D other) {
        atualizaVida();
    }

    public void atualizaVida(){
        if (!imortal) {
            vida--;
            if (vida < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
