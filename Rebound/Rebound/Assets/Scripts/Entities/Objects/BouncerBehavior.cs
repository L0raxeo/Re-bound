using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerBehavior : MonoBehaviour
{
    
    private Rigidbody2D rbPlayer;

    private void Start()
    {
        rbPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void Use()
    {
        rbPlayer.AddForce(new Vector2(0f, 5f));
    }

}
