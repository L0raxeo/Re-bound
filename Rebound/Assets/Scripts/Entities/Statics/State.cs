using UnityEngine;

[System.Serializable]
public class State
{
    public string name;

    public GameObject state;

    public GameObject parent;
    public GameObject[] children;
}
