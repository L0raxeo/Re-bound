using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    public LevelManager levelManager;

    private bool deathAnim = false;

    private void Update()
    {
        FollowPlayer();
        CheckPlayerDeathByVoid();
    }

    private void FollowPlayer()
    {
        if (player.transform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        else if (deathAnim)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 32.5f * Time.deltaTime);
            transform.position = new Vector3(0f, transform.position.y, -10f);
        }
    }

    private void CheckPlayerDeathByVoid()
    {
        if (player.transform.position.y < transform.position.y - 16.75f)
        {
            levelManager.EndGame();
        }
    }

    public void ResetCamera()
    {
        deathAnim = false;
        transform.position = new Vector3(0f, 0f, -10f);
    }

    public void DeathAnimation()
    {
        deathAnim = true;
    }

}
