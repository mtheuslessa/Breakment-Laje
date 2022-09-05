using System;
using UnityEngine;

public class Barra : MonoBehaviour {
    private Rigidbody2D _rb;
    private Vector2 _direcao;
    private float _anguloMaximoBola = 45f;

    public float velocidade = 30f;
    public float maxCima;
    public float maxBaixo;
    public int playerIndex = 0;
    public bool player1, player2;
    public Bola bolaPlayer;
    

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _rb.drag = 5f;
    }

    public int GetPlayerIndex(){
        return playerIndex;
    }

    private void FixedUpdate(){
        float verticalInput = 0;
        
        if (player1){
            verticalInput = Input.GetAxis("Player 1");
        }
        if (player2){
            verticalInput = Input.GetAxis("Player 2");
        }
        
        _rb.velocity = new Vector2(_rb.velocity.x, (verticalInput * velocidade));

        if (transform.position.y > maxCima){
            transform.position = new Vector2(transform.position.x,maxCima);
        }

        if (transform.position.y < maxBaixo){
            transform.position = new Vector2(transform.position.x,maxBaixo);
        }
    }
    
    

    /*public void PlataformMoviment (InputAction.CallbackContext context){
        Vector2 inputValue = context.ReadValue<Vector2>();
        if (context.performed){
            _rb.velocity = new Vector2(_rb.velocity.x, (inputValue.y * velocidade));
        }

        if (context.canceled){
            _rb.velocity = Vector2.zero;
        }
    }*/

    private void OnCollisionEnter2D(Collision2D col) {
        Bola bola = col.gameObject.GetComponent<Bola>();

        if (bola != null){
            Rigidbody2D rbBola = bola.GetComponent<Rigidbody2D>();
            Vector3 posicaoBarra = transform.position;
            Vector2 pontoContato = col.GetContact(0).point;

            float offset = posicaoBarra.y - pontoContato.y;
            float largura = col.otherCollider.bounds.size.y / 2;

            float anguloAtual = Vector2.SignedAngle(Vector2.right, rbBola.velocity);
            float anguloQuique = -((offset / largura) * _anguloMaximoBola);
            float novoAngulo = Mathf.Clamp(anguloAtual + anguloQuique, -_anguloMaximoBola, _anguloMaximoBola);
            
            Quaternion rotacao = Quaternion.AngleAxis(novoAngulo, Vector3.forward);
            rbBola.velocity = rotacao * Vector2.right * rbBola.velocity.magnitude;
        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("PowerUp")){
            if (col.GetComponent<PowerUp>().speed){
                bolaPlayer.PowerUpSpeed();
            }
            if (col.GetComponent<PowerUp>().slow){
                bolaPlayer.PowerUpSlow();
            }
            Destroy(col.gameObject);
        }
    }
}
