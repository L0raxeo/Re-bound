using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBtn : MonoBehaviour
{

    public LevelManager levelManager;

    public void OnClick()
    {
        levelManager.StartGame();
    }

}
