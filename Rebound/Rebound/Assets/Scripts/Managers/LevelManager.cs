using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject player;
    public GameObject lava;
    public GameObject platform;
    public GameObject m_camera;

    public PlayerBehavior playerBehavior;
    public CameraMovement cameraBehavior;

    public void EndGame()
    {
        // When in menu state, set player active to false
        platform.SetActive(false);
        lava.transform.position = new Vector3(0f, m_camera.transform.position.y - 40f, 0f);

        playerBehavior.Die();
        cameraBehavior.DeathAnimation();
    }

}
