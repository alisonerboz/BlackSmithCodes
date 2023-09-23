using Cysharp.Threading.Tasks;
using UnityEngine;

public class LookState : State
{
    public Animator anim;
    private StateManager sm;
    public IdleState IdleState;
    public bool isLook=false;
    public override State RunCurrenState()
    {
        //sm.TakeAction("look");
        anim.SetBool("walking",false);
        anim.SetBool("lookbehind",true);
        WaitForLook();
        if (isLook)
        {
            isLook = false;
            return IdleState;
            //return this;
        }
        else
        {
            return this;
        }
    }
    private async void WaitForLook()
    {
        await UniTask.Delay(4500);
        isLook = true;
    }
}