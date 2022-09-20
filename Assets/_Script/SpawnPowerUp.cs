
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPowerUp : MonoBehaviour{

    public GameObject[] powerUpDir, powerUpEsq;

    public int calcChance(){
        return Random.Range(1, 101);;
    }

    public int calcPowerUp(){
        return Random.Range(0, 2);
    }

    public void SpawnEsqLowLife(Vector3 position){
        int chance = calcChance();
        int powerUp = calcPowerUp();
        if (chance <= 15){
            Instantiate(powerUpEsq[powerUp], position, quaternion.identity);
        }
    }
    
    public void SpawnEsqMidLife(Vector3 position){
        int chance = calcChance();
        int powerUp = calcPowerUp();
        if (chance <= 30){
            Instantiate(powerUpEsq[powerUp],position, quaternion.identity);
        }
    }
    
    public void SpawnEsqHighLife(Vector3 position){
        int chance = calcChance();
        int powerUp = calcPowerUp();
        if (chance <=50){
            Instantiate(powerUpEsq[powerUp],position, quaternion.identity);
        }
    }
    
    public void SpawnDirLowLife(Vector3 position){
        int chance = calcChance();
        int powerUp = calcPowerUp();
        if (chance <= 15){
            Instantiate(powerUpDir[powerUp],position, quaternion.identity);
        }
    }
    
    public void SpawnDirMidLife(Vector3 position){
        int chance = calcChance();
        int powerUp = calcPowerUp();
        if (chance <= 30){
            Instantiate(powerUpDir[powerUp],position, quaternion.identity);
        }
    }
    
    public void SpawnDirHighLife(Vector3 position){
        int chance = calcChance();
        int powerUp = calcPowerUp();
        if (chance <= 50){
            Instantiate(powerUpDir[powerUp],position, quaternion.identity);
        }
    }
}
