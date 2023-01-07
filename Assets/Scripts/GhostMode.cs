using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostMode : MonoSingleton<GhostMode>
{
    [SerializeField] private GameObject ghost;
    [SerializeField] private Button ghostModeButton;

    public void GhostModeStart()
    {
        ghostModeButton.onClick.AddListener(GhostDistance);
    }

    private void GhostDistance()
    {
        GameObject tempRival = ghost;
        float tempDistance = 10000;

        for (int i = 0; i < FinishSystem.Instance.focusScene.Rivals.Count; i++)
        {
            if (tempDistance > Vector3.Distance(FinishSystem.Instance.focusScene.Rivals[i].transform.position, ghost.transform.position))
                tempRival = FinishSystem.Instance.focusScene.Rivals[i];
        }

        Buttons.Instance._startPanel.SetActive(false);
        GameManager.Instance.isStart = true;
        StartCoroutine(CameraSwap(tempRival));
        CharacterSwap(tempRival);
    }

    private IEnumerator CameraSwap(GameObject rival)
    {
        GhostManager.Instance.volume.components[3].active = true;
        Time.timeScale = 0.2f;
        CamMoveControl.Instance.target = rival;
        yield return new WaitForSecondsRealtime(2);
        GhostManager.Instance.volume.components[3].active = false;
        Time.timeScale = 1f;
    }

    private void CharacterSwap(GameObject rival)
    {
        GhostManager.Instance.mainPlayer = rival;
        rival.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = MaterialSystem.Instance.MainMaterial;
        rival.tag = "Main";
    }
}
