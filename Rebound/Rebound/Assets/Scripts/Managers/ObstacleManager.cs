using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public Obstacle[] obstacles;
    public GameObject m_camera;

    public Vector3 PreLoadedObstaclePosition()
    {
        float xPos = UnityEngine.Random.Range(-5.75f, 5.75f);
        float yPos = m_camera.transform.position.y + (UnityEngine.Random.Range(17.5f, 30f));

        return new Vector3(xPos, m_camera.transform.position.y + yPos, 0.0f);
    }

    public Vector3 PreLoadedBarrierPosition()
    {
        float xPos = UnityEngine.Random.Range(-4.75f, 4.75f);
        float yPos = m_camera.transform.position.y + 32.5f;

        return new Vector3(xPos, m_camera.transform.position.y + yPos, 0.0f);
    }

}
