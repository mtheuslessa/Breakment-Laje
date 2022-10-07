using System;
using UnityEngine;

public class ParticleController : MonoBehaviour{
    [SerializeField]
    public GameObject blocoAzulParticula, blocoVerdeParticula, blocoLaranjaParticula;

    public void InstantiateParticleAzul(Vector3 position){
        Instantiate(blocoAzulParticula, new Vector3(position.x, position.y, position.z - 1), Quaternion.identity);
    }
    
    public void InstantiateParticleVerde(Vector3 position){
        Instantiate(blocoVerdeParticula, new Vector3(position.x, position.y, position.z - 1), Quaternion.identity);
    }
    
    public void InstantiateParticleLaranja(Vector3 position){
        Instantiate(blocoLaranjaParticula, new Vector3(position.x, position.y, position.z - 1), Quaternion.identity);
    }
}
