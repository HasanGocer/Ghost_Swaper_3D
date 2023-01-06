using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class AnimController : MonoBehaviour
{
    [SerializeField] private AnimancerComponent character;
    [SerializeField] private AnimationClip walk, fireWalk, fireIdle, death, �dle;

    public void CallIdleAnim()
    {
        character.Play(�dle, 0.2f);
    }
    public void CallDeadAnim()
    {
        character.Play(death, 0.2f);
    }
    public void CallWalkAnim()
    {
        character.Play(walk, 0.2f);
    }
    public IEnumerator CallFireAnim(float gunReloadTime, bool walk, bool �dle)
    {
        if (walk)
            character.Play(fireWalk, 0.1f);
        if (�dle)
            character.Play(fireIdle, 0.1f);

        yield return new WaitForSeconds(gunReloadTime);
        if (walk)
            character.Play(walk, 0.2f);
        if (�dle)
            character.Play(�dle, 0.2f);
    }
}
