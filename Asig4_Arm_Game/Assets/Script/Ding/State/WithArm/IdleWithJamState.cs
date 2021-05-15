using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdleWithJamState : State
{
    CenterController centerController;
  

    public IdleWithJamState(CenterController centerController)
    {
        this.centerController = centerController;
       centerController.JamStateRestTime= centerController.JamStateTime;
    }

    public override void beginFunc()
    {
        centerController.curForm = Form.jam;
        centerController.rotateArm.activate();
        centerController.rotateArm.stopRotate();
        centerController.playerAniClip("ArmIdle");
        UICenter.instance.instanJamShower(centerController);

    }
    public override void excute()
    {
        base.excute();
        centerController.rotateArm.stopRotate();
        if (Input.GetKey(KeyCode.J))
            centerController.slimeArm.activate();
        else
            centerController.slimeArm.deactivate();

        if (Input.GetKey(KeyCode.A))
            centerController.rotateArm.rotateLeft();
        if (Input.GetKey(KeyCode.D))
            centerController.rotateArm.rotateRight();
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && centerController.rotateArm.isEnabled())
            centerController.rotateArm.stopRotate();
        centerController.JamStateRestTime -= Time.deltaTime;
        if (centerController.JamStateRestTime <= 0)
        { 
            centerController.changeBackfromJamTrgger = true; 
        
        }
     

    }
    public override void leaveState()
    {
        base.leaveState();
        centerController.slimeArm.deactivate();
        centerController.JamStateRestTime = 0;
        UICenter.instance.destroyJamShower();
    }
    public override State tryTrans()
    {
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        //    return new JamRotateMoveState(centerController);
  
        if (centerController.state_goBackFromJamForm())
            return new IdleWithArmState(centerController);
        if (Input.GetKey(KeyCode.K))
            return new ChargeArmState(centerController);
        if (Input.GetKey(KeyCode.Space) && pausing == false)
        { return new IdleState(centerController); }

        return this;
    }


}