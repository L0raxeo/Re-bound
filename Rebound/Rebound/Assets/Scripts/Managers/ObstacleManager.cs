using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public GameObject m_camera;

    public Vector3 PreLoadedObstaclePosition()
    {
        float xPos = Random.Range(-5.75f, 5.75f);
        float yPos = Random.Range(17.5f, 30f);

        return new Vector3(xPos, m_camera.transform.position.y + yPos, 0.0f);
    }

    public Vector3 PreLoadedBarrierPosition()
    {
        float xPos = Random.Range(-5.25f, 5.25f);
        float yPos = 32.5f;

        return new Vector3(xPos, m_camera.transform.position.y + yPos, 0.0f);
    }

}
