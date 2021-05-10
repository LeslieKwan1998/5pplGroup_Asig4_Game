using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    MonoBehaviour mono;
    State curState;
    public T obj;
    public StateMachine(MonoBehaviour mono, T t, State startState)
    {
        this.mono = mono;
        obj = t;
        curState = startState;
    }


    public void excute()
    {
        mono.StartCoroutine(ieExcute());

    }
    public string getCurState()
    {
        return curState.ToString();
    }
    IEnumerator ieExcute()
    {
        while (true)
        {
            
            curState.begin(mono);
            yield return new WaitForEndOfFrame();
         
            curState.excute();
            State tempState = curState.tryTrans();
            if (tempState == curState)
            {
                curState = tempState;
            }
            else
            {
                curState.leaveState();
                curState = tempState;
            }
           

        }
    }

}