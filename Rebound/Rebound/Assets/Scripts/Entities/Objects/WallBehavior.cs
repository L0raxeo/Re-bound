using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{

    public GameObject m_camera;

    void Update()
    {
        transform.position = new Vector3(m_camera.transform.position.x, m_camera.transform.position.y, -5f);
    }

}
