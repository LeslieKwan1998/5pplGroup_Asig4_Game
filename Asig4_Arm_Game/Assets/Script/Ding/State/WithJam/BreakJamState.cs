using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakJamState : State
{

    CenterController centerController;
    bool freze= false;

    public BreakJamState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {
      //  centerController.StartCoroutine(aniProcess());
    }
    public override void leaveState()
    {
        base.leaveState();
        
       // centerController.getArmController().animator.enabled = false;

    }
    public override State tryTrans()
    {
      
        //Animator ani = centerController.getArmController().animator;
        //AnimatorStateInfo info = ani.GetCurrentAnimatorStateInfo(0);
        //Debug.Log("time" + info.normalizedTime);
        //// 判断动画是否播放完成
        //if ( info.normalizedTime >= 1f)
            return new IdleWithJamState(centerController);
        return this;
    }

    public override void excute()
    {
        base.excute();
        if (freze)
            centerController.getRig().velocity = Vector2.zero;
    }
    IEnumerator aniProcess()
    {
        centerController.playerAniClip("Player@BreakJam");
        centerController.basicMoveMent.Jump();
        yield return new WaitUntil(aniFinishJudge);
        freze = true;
        centerController.getArmController().animator.enabled = true;
        centerController.getArmController().animator.Play("Arm@BreakJam");
    }
    bool aniFinishJudge()
    {
        Animator animator = centerController.playerAni;
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        // 判断动画是否播放完成
        if (info.normalizedTime >= 1.0f)
            return true;
        return false;
    }
}
