using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBehavior : MonoBehaviour
{

    private Vector3 initPos;

    private string direction;
    private int movementMode;

    private void Start()
    {
        initPos = transform.position;
        movementMode = Random.Range(1,4);

        switch (movementMode)
        {
            case 1:
                direction = "up";
                break;
            case 2:
                direction = "right";
                break;
        }
    }

    private void Update()
    {
        switch (movementMode)
        {
            case 1:
                MoveVertically();
                break;
            case 2:
                MoveHorizontally();
                break;
            case 3:
                // remain idle
                break;
        }
    }

    private void MoveVertically()
    {
        if (direction == "up")
        {
            transform.position += new Vector3(0f, 5f, 0f) * Time.deltaTime;

            if (transform.position.y > initPos.y + 2.25f)
                direction = "down";
        }
        else
        {
            transform.position -= new Vector3(0f, 5f, 0f) * Time.deltaTime;

            if (transform.position.y < initPos.y - 2.25f)
                direction = "up";
        }
    }

    private void MoveHorizontally()
    {
        if (direction == "right")
        {
            transform.position += new Vector3(5f, 0f, 0f) * Time.deltaTime;

            if (transform.position.x > 4.75f)
                direction = "left";
        }
        else
        {
            transform.position -= new Vector3(5f, 0f, 0f) * Time.deltaTime;

            if (transform.position.x < -4.75f)
                direction = "right";
        }
    }

}
