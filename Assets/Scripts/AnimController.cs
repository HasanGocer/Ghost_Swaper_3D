using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class AnimController : MonoBehaviour
{
    [SerializeField] private AnimancerComponent character;
    [SerializeField] private AnimationClip walk, fireWalk, fireIdle, death, ýdle;

    public void CallIdleAnim()
    {
        character.Play(ýdle, 0.2f);
    }
    public void CallDeadAnim()
    {
        character.Play(death, 0.2f);
    }
    public void CallWalkAnim()
    {
        character.Play(walk, 0.2f);
    }
    public IEnumerator CallFireAnim(float gunReloadTime, bool walk, bool ýdle)
    {
        if (walk)
            character.Play(fireWalk, 0.1f);
        if (ýdle)
            character.Play(fireIdle, 0.1f);

        yield return new WaitForSeconds(gunReloadTime);
        if (walk)
            character.Play(walk, 0.2f);
        if (ýdle)
            character.Play(ýdle, 0.2f);
    }
}
