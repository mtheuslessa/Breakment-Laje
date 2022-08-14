using UnityEngine;
using UnityEngine.InputSystem;

public class Barra : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector2 direcao;
    private float anguloMaximoBola = 45f;

    public float velocidade = 30f;
    public bool player1;
    public bool player2;
    public float maxCima;
    public float maxBaixo;
    

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 5f;
    }

    private void FixedUpdate(){
        if (transform.position.y > maxCima){
            transform.position = new Vector2(transform.position.x,maxCima);
        }

        if (transform.position.y < maxBaixo){
            transform.position = new Vector2(transform.position.x,maxBaixo);
        }
    }

    public void PlataformMoviment (InputAction.CallbackContext context){
        Vector2 inputValue = context.ReadValue<Vector2>();
        if (context.performed){
            rb.velocity = new Vector2(rb.velocity.x, (inputValue.y * velocidade));
        }

        if (context.canceled){
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        Bola bola = col.gameObject.GetComponent<Bola>();

        if (bola != null){
            Rigidbody2D rbBola = bola.GetComponent<Rigidbody2D>();
            Vector3 posicaoBarra = transform.position;
            Vector2 pontoContato = col.GetContact(0).point;

            float offset = posicaoBarra.y - pontoContato.y;
            float largura = col.otherCollider.bounds.size.y / 2;

            float anguloAtual = Vector2.SignedAngle(Vector2.right, rbBola.velocity);
            float anguloQuique = -((offset / largura) * anguloMaximoBola);
            float novoAngulo = Mathf.Clamp(anguloAtual + anguloQuique, -anguloMaximoBola, anguloMaximoBola);
            
            Quaternion rotacao = Quaternion.AngleAxis(novoAngulo, Vector3.forward);
            rbBola.velocity = rotacao * Vector2.right * rbBola.velocity.magnitude;
        }
    }
}
