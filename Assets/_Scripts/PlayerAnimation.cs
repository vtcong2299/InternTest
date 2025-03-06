using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    string stateRun = "isRun";
    string stateJump = "isJump";
    string stateDead = "isDead";
    string stateInGround = "inGround";
    string exitAnim = "isExit";
    
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void AnimRun()
    {
        animator.SetBool(stateRun, true);
    }
    public void AnimJump(bool state)
    {
        animator.SetBool(stateJump, state);
    }
    public void AnimIdle()
    {
        animator.SetBool(stateRun, false);        
    }
    public void AnimDead()
    {
        animator.SetTrigger(stateDead);
    }
    public void ExitAnim()
    {
        animator.SetTrigger(exitAnim);
    }
    public void SetStateInGround(bool state)
    {
        animator.SetBool(stateInGround, state);
    }
}
