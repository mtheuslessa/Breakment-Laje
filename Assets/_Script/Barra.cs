using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Barra : MonoBehaviour {
    private Rigidbody2D _rb;
    private Vector2 _direcao;
    private float _anguloMaximoBola = 45f;
    private float timer = 0;
    private AudioSource somBarra;

    public float velocidade = 30f;
    public float maxCima;
    public float maxBaixo;
    public int playerIndex = 0;
    public bool player1, player2;
    public Bola bolaPlayer, bolaEnemy;
    public GameObject newBola;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        somBarra = GetComponent<AudioSource>();
        _rb.drag = 5f;
    }

    public int GetPlayerIndex(){
        return playerIndex;
    }

    private void FixedUpdate(){
        float verticalInput = 0;

        timer += Time.deltaTime;
        
        if (timer >= 30)
            resetGame();

        if (Gamepad.all[0].leftStick.y.ReadValue() != 0){
            resetTimer();
        } 
        
        if (Gamepad.all[1].leftStick.y.ReadValue() != 0){
            resetTimer();
        }

        if (player1){
            verticalInput = Gamepad.all[0].leftStick.y.ReadValue();
        }
        if (player2){
            verticalInput = Gamepad.all[1].leftStick.y.ReadValue();
        }
        
        _rb.velocity = new Vector2(_rb.velocity.x, (verticalInput * velocidade));

        if (transform.position.y > maxCima){
            transform.position = new Vector2(transform.position.x,maxCima);
        }

        if (transform.position.y < maxBaixo){
            transform.position = new Vector2(transform.position.x,maxBaixo);
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        Bola bola = col.gameObject.GetComponent<Bola>();
        
        somBarra.Play();

        if (bola != null){
            Rigidbody2D rbBola = bola.GetComponent<Rigidbody2D>();
            Vector3 posicaoBarra = transform.position;
            Vector2 pontoContato = col.GetContact(0).point;

            float offset = posicaoBarra.y - pontoContato.y;
            float largura = col.otherCollider.bounds.size.y / 2;

            float anguloAtual = 0;
            
            if(player1)
                anguloAtual = Vector2.SignedAngle(Vector2.right, rbBola.velocity);
            if(player2)
                anguloAtual = Vector2.SignedAngle(Vector2.left, rbBola.velocity);
            float anguloQuique = -((offset / largura) * _anguloMaximoBola);
            float novoAngulo = Mathf.Clamp(anguloAtual + anguloQuique, -_anguloMaximoBola, _anguloMaximoBola);
            
            
            if(player1){
                Quaternion rotacao = Quaternion.AngleAxis(novoAngulo, Vector3.forward);
                rbBola.velocity = rotacao * Vector2.right * rbBola.velocity.magnitude;
            }

            if (player2){
                Quaternion rotacao = Quaternion.AngleAxis(novoAngulo, -Vector3.forward);
                rbBola.velocity = rotacao * Vector2.left * rbBola.velocity.magnitude;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("PowerUp")){
            if (col.GetComponent<PowerUp>().speed){
                bolaPlayer.PowerUpSpeed();
            }
            if (col.GetComponent<PowerUp>().slow){
                bolaEnemy.PowerUpSlow();
            }
            if (col.GetComponent<PowerUp>().multi){
                Instantiate(newBola, bolaPlayer.getPosicaoOriginal(), Quaternion.identity);
            }
            Destroy(col.gameObject);
        }
    }

    public void resetTimer(){
        timer = 0;
    }

    public void resetGame(){
        SceneManager.LoadScene("Menu");
    }
}
