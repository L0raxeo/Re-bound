using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehavior : MonoBehaviour
{

    [HideInInspector]
    public GameObject player;
    public GameObject nodePref;
    [HideInInspector]
    public GameObject lastNode;

    public Vector2 destiny;

    public float DEFAULT_SPEED = 1f;
    public float distance = 2f;

    public LineRenderer lineRenderer;

    private int vertexCount = 2;
    public List<GameObject> Nodes = new List<GameObject>();

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        lastNode = transform.gameObject;
        Nodes.Add(transform.gameObject);
    }

    private bool done = false;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destiny, DEFAULT_SPEED);
    
        if ((Vector2) transform.position != destiny)
        {
            if (Vector2.Distance(player.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();
            }
        }
        else if (!done)
        {
            done = true;

            while (Vector2.Distance(player.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();
            }

            lastNode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
        }

        RenderLine();
    }

    private void RenderLine()
    {
        lineRenderer.positionCount = vertexCount;

        int i;
        for (i = 0; i < Nodes.Count; i++)
        {
            lineRenderer.SetPosition(i, Nodes[i].transform.position);
        }

        lineRenderer.SetPosition(i, player.transform.position);
    }

    private void CreateNode()
    {
        Vector2 pos2Create = player.transform.position - lastNode.transform.position;
        pos2Create.Normalize();
        pos2Create *= distance;
        pos2Create += (Vector2)lastNode.transform.position;

        GameObject go = (GameObject)Instantiate(nodePref, pos2Create, Quaternion.identity);

        go.transform.SetParent(transform);
        lastNode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();
        lastNode = go;

        Nodes.Add(lastNode);
        vertexCount++;
    }

}
