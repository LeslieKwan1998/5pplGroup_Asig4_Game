using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    CenterController centerController;

    public JumpState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {
        Debug.Log("jump");
        centerController.basicMoveMent.Jump();
        //  centerController.setPlayerAni("NormalJump");
        centerController.playerAniClip("NormalJump");
    }

    public override State tryTrans()
    {
        Animator animator= centerController.playerAni;
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        // 判断动画是否播放完成
        if (info.normalizedTime >= 1.0f)
            return new InAirUpState(centerController);
        if (Input.GetKey(KeyCode.K))
            return new SuperJumpState(centerController);
        if (Input.GetKey(KeyCode.Space) )
        {
            centerController.basicMoveMent.Jump() ;
            return new IdleWithArmState(centerController);
        }
        return this;
       
    }
}
