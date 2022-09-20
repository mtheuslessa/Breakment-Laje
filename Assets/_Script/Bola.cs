using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Bola : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector3 posicaoOriginal;
    private float _speedTimer = 5f;
    private float _slowTimer = 5f;
    private float _timerAtual = 0f;
    private bool speed, slow, multi;
    

    public float velocidade = 5f;
    public bool player1;
    public bool player2;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        posicaoOriginal = transform.position;
    }

    private void Start() {
        Invoke(nameof(SoltarBolinha), 1f);
    }
    
    private void FixedUpdate(){
        if (speed){
            if (_timerAtual < _speedTimer){
                _timerAtual += Time.deltaTime;
            }

            if (_timerAtual >= _speedTimer){
                _timerAtual = 0;
                velocidade /= 2;
                speed = false;
            }
        }
        
        if (slow){
            if (_timerAtual < _slowTimer){
                _timerAtual += Time.deltaTime;
            }

            if (_timerAtual >= _slowTimer){
                _timerAtual = 0;
                velocidade *= 2;
                slow = false;
            }
        }
        
        rb.velocity = rb.velocity.normalized * velocidade;
    }
    
    public void SoltarBolinha(){
        Vector2 forca = Vector2.zero;
        forca.y = Random.Range(-1, 2);
        if(player1)
            forca.x = 1f; 
        if(player2)
            forca.x = -1f;
        rb.AddForce(forca.normalized * velocidade);    
    }

    private void OnCollisionEnter2D(Collision2D col){
        //VibrarControle(Random.Range(0f, 0.3f));
    }

    private void VibrarControle(float duracao){
        if (player1){
            Gamepad.all[0].SetMotorSpeeds(Random.Range(0.1f, 0.3f), Random.Range(0.1f, 0.5f));
        }
        if (player2){
            Gamepad.all[1].SetMotorSpeeds(Random.Range(0.1f, 0.3f), Random.Range(0.1f, 0.5f));
        }

        Invoke(nameof(PararVibrar), duracao);
    }

    private void PararVibrar(){
        Gamepad.current.SetMotorSpeeds(0, 0);
    }

    public void Reset(){
        transform.position = posicaoOriginal;
        rb.velocity = Vector2.zero;
        Invoke(nameof(SoltarBolinha), 2f);
    }

    public void PowerUpSpeed(){
        if (slow){
            slow = false;
            _timerAtual = 0;
            velocidade *= 2;
        }

        if (!speed){
            speed = true;
            velocidade *= 2;
        }
    }
    
    public void PowerUpSlow(){
        if (speed){
            speed = false;
            _timerAtual = 0;
            velocidade /= 2;
        }

        if (!slow){
            slow = true;
            velocidade /= 2;
        }
    }

    public Vector3 getPosicaoOriginal(){
        return posicaoOriginal;
    }
}
