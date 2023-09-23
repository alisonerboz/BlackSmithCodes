using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class StateManager : MonoBehaviour
{
    public State currentState;
    public Animator animatorr;
    void Update()
    {
        RunStateMachine();
    }
    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrenState();
        if (nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }
    private void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
        //Debug.Log(currentState);
    }

    public void TakeAction(string state)
    {
        //Debug.Log("geldi");
        if(state=="Idle")
        {
            animatorr.SetBool("Idle",true);   
        }
        if(state=="walking")
        {
            animatorr.SetBool("lookbehind",false);
            animatorr.SetBool("walking",true);   
        }
        if(state=="look")
        {
            animatorr.SetBool("walking",false);
            animatorr.SetBool("lookbehind",true);   
        }
    }
}