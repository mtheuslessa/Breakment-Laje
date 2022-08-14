using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Bola : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector3 posicaoOriginal;
    

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
        Invoke(nameof(SoltarBolinha), 1f);
    }
}
