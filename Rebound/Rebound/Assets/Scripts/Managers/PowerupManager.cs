using System.Collections;
using System;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Use()
    {
        if (gameObject.name.Contains("Bouncer"))
            UseBouncer();
    }

    private void UseBouncer()
    {
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1250f));
    }

}
