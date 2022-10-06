using System;
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
    private ScreenShaker shaker;
    private SoundManager sounds;
    private GameObject gameManager;
    
    public float velocidade = 5f;
    public bool player1;
    public bool player2;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        posicaoOriginal = transform.position;
        shaker = FindObjectOfType<ScreenShaker>();
        sounds = FindObjectOfType<SoundManager>();
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
                velocidade /= 1.5f;
                speed = false;
            }
        }
        
        if (slow){
            if (_timerAtual < _slowTimer){
                _timerAtual += Time.deltaTime;
            }

            if (_timerAtual >= _slowTimer){
                _timerAtual = 0;
                velocidade *= 1.5f;
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
        VibrarControle(Random.Range(0f, 0.3f));
        shaker.StartShake(Random.Range(0f, 0.2f), Random.Range(0f, 0.1f));
        
        if (col.gameObject.CompareTag("Colisor")){
            sounds.PlayBolinhaParede();
        }
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
        //Gamepad.current.SetMotorSpeeds(0, 0);
        InputSystem.ResetHaptics();
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
            velocidade *= 1.5f;
        }

        if (!speed){
            speed = true;
            velocidade *= 1.5f;
        }
    }
    
    public void PowerUpSlow(){
        if (speed){
            speed = false;
            _timerAtual = 0;
            velocidade /= 1.5f;
        }

        if (!slow){
            slow = true;
            velocidade /= 1.5f;
        }
    }

    public Vector3 getPosicaoOriginal(){
        return posicaoOriginal;
    }

    private void OnApplicationQuit(){
        InputSystem.ResetHaptics();
    }
}
