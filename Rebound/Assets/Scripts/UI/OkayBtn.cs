using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkayBtn : MonoBehaviour
{

    public void OnClick()
    {
        GameObject.FindObjectOfType<StateManager>().SetState("Menu State", false);
    }

}
