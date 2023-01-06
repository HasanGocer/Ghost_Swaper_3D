using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSystem : MonoSingleton<FinishSystem>
{
    public RoomManager.RoomScens focusScene;
    public int deadRival = 0;

    public void FinishCheck()
    {
        if (focusScene.rivalCount == deadRival)
        {
            Buttons.Instance.winPanel.SetActive(true);
            StartCoroutine(NoThanx());
            StartCoroutine(BarSystem.Instance.BarImageFillAmountIenum());

            //bulunduðumuz karakteri öldür 
            //finish
        }
    }

    public IEnumerator NoThanx()
    {
        yield return new WaitForSeconds(2);
        Buttons.Instance.winButton.gameObject.SetActive(true);
    }
}
