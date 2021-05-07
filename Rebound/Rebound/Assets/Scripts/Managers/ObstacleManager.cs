using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public Obstacle[] obstacles;
    public GameObject m_camera;

    public int ObjectLimit;
    private float yNextPos = 0f;

    private void Update()
    {
        if (m_camera.transform.position.y > yNextPos)
        {
            yNextPos += 30f;
            GenerateLevel();
        }

        DestroyObjectsInVoid();
    }

    private void DestroyObjectsInVoid()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Powerup"))
        {
            if (o.transform.position.y < m_camera.transform.position.y - 16f)
                Destroy(o);
        }

        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            if (o.transform.position.y < m_camera.transform.position.y - 16f)
                Destroy(o);
        }
    }

    private void GenerateLevel()
    {
        // Instantiate barrier
        if ((int) UnityEngine.Random.Range(1,3) == 1)
            Instantiate(obstacles[0].prefab, PreLoadedBarrierPosition(), Quaternion.identity);

        while (GameObject.FindGameObjectsWithTag("Obstacle").Length + GameObject.FindGameObjectsWithTag("Powerup").Length < ObjectLimit)
        {
            GameObject spawnObj = Instantiate(obstacles[(int) UnityEngine.Random.Range(1, 4)].prefab, PreLoadedObstaclePosition(), Quaternion.identity);
            foreach (GameObject checkedObj in GameObject.FindGameObjectsWithTag("Obstacle"))
            {
                if (spawnObj == checkedObj)
                    continue;

                if (!PointIsValid(spawnObj, checkedObj))
                {
                    Destroy(spawnObj);
                    break;
                }
            }

            foreach (GameObject checkedObj in GameObject.FindGameObjectsWithTag("Powerup"))
            {
                if (spawnObj == checkedObj)
                    continue;

                if (!PointIsValid(spawnObj, checkedObj))
                {
                    Destroy(spawnObj);
                    break;
                }
            }
        }
    }

    private bool PointIsValid(GameObject spawnObj, GameObject checkedObj)
    {
        if (Vector2.Distance(spawnObj.transform.position, checkedObj.transform.position) < 5)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public Vector3 PreLoadedObstaclePosition()
    {
        float xPos = UnityEngine.Random.Range(-5.75f, 5.75f);
        float yPos = m_camera.transform.position.y + (UnityEngine.Random.Range(12.5f, 30f));

        return new Vector3(xPos, yPos, 0.0f);
    }

    public Vector3 PreLoadedBarrierPosition()
    {
        float xPos = UnityEngine.Random.Range(-4.75f, 4.75f);
        float yPos = m_camera.transform.position.y + 32.5f;

        return new Vector3(xPos, yPos, 0.0f);
    }

}
