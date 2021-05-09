using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{

    private float shakeTimeRemaining, shakePower;

    private void Update()
    {
        // StartShake(0.5f, 1f);
    }

    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xAmt = Random.Range(-1f, 1f) * shakePower;
            float yAmt = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmt, yAmt, 0f);
        }
        else
        {
            transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        }
    }

    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;
    }
}
