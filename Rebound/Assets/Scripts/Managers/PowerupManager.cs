using System.Collections.Generic;
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
        else if (gameObject.name.Contains("Destroyer"))
            UseDestroyer();
    }

    private void UseBouncer()
    {
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1150f));
    }

    private void UseDestroyer()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Destroyed");
        player.GetComponent<PlayerBehavior>().destroyCount = 3;
    }

    public void DestroyObjectAfterAnimation()
    {
        Destroy(gameObject);
    }

}
