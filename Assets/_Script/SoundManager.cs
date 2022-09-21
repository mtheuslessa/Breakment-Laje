
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{
    public AudioSource bolinhaQuicando, bolinhaParede, click, bolinhaPlataforma, blocoQuebrando;

    public void PlayBolinhaQuicando(){
        bolinhaQuicando.Play();
    } 
    public void PlayBolinhaParede(){
        bolinhaParede.Play();
    }
    public void PlayClick(){
        click.Play();
    }
    public void PlayBolinhaPlataforma(){
        bolinhaPlataforma.Play();
    }
    public void PlayBlocoQuebrando(){
        //if(!blocoQuebrando.isPlaying)
            blocoQuebrando.Play();
    }
}
