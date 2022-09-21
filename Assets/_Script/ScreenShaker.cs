using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScreenShaker : MonoBehaviour{
    private float shakeTimeRemaining, shakePower;

    private void LateUpdate(){
        if (shakeTimeRemaining > 0){
            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);
        } else{
            transform.position = new Vector3(0, 0, -10);
        }
    }

    public void StartShake(float lenght, float power){
        if (shakeTimeRemaining <= 0){
            shakeTimeRemaining = lenght;
            shakePower = power;
        }
    }
}
