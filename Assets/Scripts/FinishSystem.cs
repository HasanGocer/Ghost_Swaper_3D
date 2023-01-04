using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSystem : MonoSingleton<FinishSystem>
{
    public RoomManager.RoomScens focusScene;
    public int deadRival = 0;

    public void FinishCheck()
    {
        if (focusScene.rivalCount - 1 == deadRival)
        {
            //bulunduðumuz karakteri öldür 
            //finish
        }
    }
}
