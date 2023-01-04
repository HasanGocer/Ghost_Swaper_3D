using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class AnimController : MonoBehaviour
{
    [SerializeField] private AnimancerComponent character;
    [SerializeField] private AnimationClip walk, fire, death, ýdle;

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
        character.Play(fire, 0.1f);
        yield return new WaitForSeconds(gunReloadTime);
        if (walk)
            character.Play(walk, 0.2f);
        if (ýdle)
            character.Play(ýdle, 0.2f);
    }
}
