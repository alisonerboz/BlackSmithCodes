using Cysharp.Threading.Tasks;
using UnityEngine;

public class WalkingState : State
{
    public Animator anim;
    private StateManager sm;
    public LookState lookState;
    public bool isWalking=false;
    public override State RunCurrenState()
    {
        //sm.TakeAction("walking");
        anim.SetBool("lookbehind",false);
        anim.SetBool("walking",true);
        WaitForWalking();
        if (isWalking)
        {
            isWalking = false;
            return lookState;
        }
        else
        {
            return this;
        }
    }
    private async void WaitForWalking()
    {
        await UniTask.Delay(6000);
        isWalking = true;
    }
    
}