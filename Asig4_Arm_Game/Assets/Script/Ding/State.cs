using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected bool isBegin = false;
    protected bool pausing =true;
    public void begin(MonoBehaviour mono)
    {

        if (isBegin == false)
        {
            beginFunc();
            mono.StartCoroutine(switchCD());
            isBegin = true;
        }
    }
    public abstract void beginFunc();

    public abstract State tryTrans();
    public virtual void excute()
    {
        if (Input.GetKey(KeyCode.S))
            Debug.Log(this);
    }

    public virtual void leaveState()
    {

    }
    public virtual void returnFuc() //再次返回的时候调用
    {

    }
    IEnumerator switchCD()
    {
        yield return new WaitForSeconds(0.2f);
        pausing = false;

    }
}
