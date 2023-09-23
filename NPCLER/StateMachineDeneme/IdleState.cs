using Cysharp.Threading.Tasks;
using UnityEngine;

public class IdleState : State
{
    public Animator anim;
    public WalkingState walkingState;
    public bool isStands=false;
    
    public override State RunCurrenState()
    {
        anim.SetBool("lookbehind",false);
        anim.SetBool("walking",false);
        WaitForIdle();
        if (isStands)
        {
            isStands = false;
            return walkingState;
        }
        else
        {
            return this;
        }
    }
    private async void WaitForIdle()
    {
        await UniTask.Delay(3000);
        isStands = true;
    }
}