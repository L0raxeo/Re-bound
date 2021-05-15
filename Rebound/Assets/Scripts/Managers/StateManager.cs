using System;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    public State[] states;

    [HideInInspector]
    public string currentState;
    [HideInInspector]
    public string previousState;

    public GameObject canvas;

    private void Start()
    {
        currentState = "Menu State";
    }

    public void SetState(string name, bool overlay)
    {
        if (!overlay)
            Array.Find(states, state => state.name == currentState).state.SetActive(false);

        previousState = currentState;

        State s = Array.Find(states, state => state.name == name);
        s.state.SetActive(true);
        currentState = name;

        foreach (GameObject child in s.children)
            child.SetActive(false);
    }

}
