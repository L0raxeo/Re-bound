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

    public StateManager stateManager;

    public void StartGame()
    {
        platform.SetActive(true);
        lava.transform.position = new Vector3(0f, -21.4835f, 0f);
        ObstacleManager.DestroyAllObstacles();

        stateManager.SetState("Game State", false);
        playerBehavior.Respawn();
        cameraBehavior.ResetCamera();
    }

    public void EndGame()
    {
        // When in menu state, set player active to false
        platform.SetActive(false);
        lava.transform.position = new Vector3(0f, m_camera.transform.position.y - 40f, 0f);

        playerBehavior.Die();
        cameraBehavior.DeathAnimation();
    }

}
