using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdleWithArmState : State
{
    CenterController centerController;
    bool muteAudio = false;
    public IdleWithArmState(CenterController centerController,bool muteAudio = false)
    {
        this.centerController = centerController;
        this.muteAudio = muteAudio;
    }

    public override void beginFunc()
    {
        centerController.curForm = Form.arm;
        centerController.rotateArm.activate();
        centerController.rotateArm.stopRotate();
        centerController.playerAniClip("ArmIdle");
        if(!muteAudio)
        centerController.playAudio("PullOutSpatula");
    }
    public override void excute()
    {
        base.excute();
     
        if (Input.GetKey(KeyCode.A))
            centerController.rotateArm.rotateLeft();
        if (Input.GetKey(KeyCode.D))
            centerController.rotateArm.rotateRight();
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && centerController.rotateArm.isEnabled())
            centerController.rotateArm.stopRotate();

    }
    public override void leaveState()
    {
        base.leaveState();
    
    }
    public override State tryTrans()
    {

        if (Input.GetKey(KeyCode.Space) && pausing == false)
        {
            centerController.playAudio("PutbackSpatula");
            return new IdleState(centerController); }
        if (centerController.state_goJamForm())
            return new BreakJamState(centerController);
        if (Input.GetKey(KeyCode.J) )
            return new HitState(centerController);
        if (Input.GetKey(KeyCode.K) )
            return new ChargeArmState(centerController);
        return this;
    }

 
}