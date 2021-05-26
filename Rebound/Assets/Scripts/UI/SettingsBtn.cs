using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsBtn : MonoBehaviour
{
    
    public void OnClick()
    {
        GameObject.FindObjectOfType<StateManager>().SetState("Settings State", false);
    }

}
