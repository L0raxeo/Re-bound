using UnityEngine;

public class BackBtn : MonoBehaviour
{

    public void OnClick()
    {
        GameObject.FindObjectOfType<StateManager>().SetState("Menu State", false);
    }

}
