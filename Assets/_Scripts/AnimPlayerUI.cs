using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayerUI : Singleton<AnimPlayerUI>
{
    private Animator animator;
    string stateDead = "isDead";

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponentInChildren<Animator>();
    }
    public void AnimDead(bool state)
    {
        animator.SetBool(stateDead, state);
    }
}
