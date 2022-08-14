using UnityEngine;
using Random = UnityEngine.Random;

public class Bola : MonoBehaviour {
    private Rigidbody2D rb;
    public float velocidade = 5f;
    public float anguloMaximoBola = 75f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
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
        Debug.Log(forca.y);
        forca.x = 1f;
        rb.AddForce(forca.normalized * velocidade);    
    }
}
