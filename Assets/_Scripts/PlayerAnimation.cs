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
        animator.SetBool(stateInGround, true);
    }
    public void AnimJump()
    {
        animator.SetTrigger(stateJump);
        animator.SetBool(stateInGround, true) ;
    }
    public void AnimIdle()
    {
        animator.SetBool(stateInGround, true);
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
}
