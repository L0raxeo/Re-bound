using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHook : MonoBehaviour
{

    public GameObject hook;

    public bool isRopeActive;

    [HideInInspector]
    public GameObject curHook;

    public bool Throw(Vector2 target)
    {
        GameObject swingBlock = GameObject.Find("Swing Block");

        if (swingBlock != null && swingBlock.GetComponent<CircleCollider2D>().bounds.Contains(target))
        {
            Grapple(target);
        }
        else
        {
            return false;
        }

        return true;
    }

    private void Grapple(Vector2 destination)
    {
        if (!isRopeActive)
        {
            Vector2 destiny = destination;
            curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);
            curHook.GetComponent<RopeBehavior>().destiny = destiny;

            isRopeActive = true;
        }
        else
        {
            Destroy(curHook);

            isRopeActive = false;
        }
    }

}
