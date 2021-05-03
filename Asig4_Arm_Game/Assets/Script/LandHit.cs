using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LandHit : MonoBehaviour, ILandHit
{
    bool _isEnable;
    IRotateArm rotateArm;
    ArmController armController;
    [SerializeField]
    GameObject BoomEFprefab;
    public void disableAbility()
    {
        _isEnable = false;
    }

    public void enableAbility(CenterController centerController)
    {
        _isEnable = true;
        rotateArm = centerController.getRotateArm();
        armController = centerController.getArmController();
    }

    public void Hit()
    {
        StartCoroutine(landHitingProcess());
    }

    public bool isEnabled()
    {
        return _isEnable;
    }

    IEnumerator landHitingProcess()
    {
        float rotateTime = 0;
        while (rotateTime <= 0.05f)//  防止误触
        {
            rotateTime += Time.deltaTime;
            rotateArm.fastRotate();
            yield return new WaitForEndOfFrame();
        }
        do
        {
      
            rotateTime += Time.deltaTime;
            rotateArm.fastRotate();
            yield return new WaitForEndOfFrame();
            
            if (armController.isHiting() == true && rotateTime <= 0.1f) //防止短时间蓄力
            {
                attackFail();
                yield break;
            }
        }
        while (armController.isHiting() == false && rotateTime<=10f) ;

        initialBoom(rotateTime);
        
    }

    void attackFail()
    {
        rotateArm.stopRotate();
    }

    void initialBoom(float rotateTime)
    {
        float basef = 1;
        if (rotateTime >= 0.5)
            basef = 5;
        if (rotateTime >= 0.7)
            basef = 10;
        if (rotateTime >= 0.8)
            basef = 20;
        if(rotateTime >= 0.9)
            basef = 30;
        if (rotateTime >= 1)
            basef = 50;
        if (rotateTime >= 1.1)
            basef = 70;
        if (rotateTime >= 1.2)
            basef = 90;
        if (rotateTime >= 1.3)
            basef = 110;
        if (rotateTime >= 1.4)
            basef = 130;

        float booMPower = rotateTime * rotateTime *basef + 0.3f  ;
        Debug.Log("Roteta" + rotateTime * rotateTime *basef+ "velo " );
        GameObject a = Instantiate(BoomEFprefab, armController.getHitPos(),Quaternion.identity);
        a.transform.localScale *= 1 + rotateTime*2;
        CinemachineCollisionImpulseSource cs = this.GetComponent<CinemachineCollisionImpulseSource>();
        cs.m_ImpulseDefinition.m_AmplitudeGain =booMPower;
        cs.GenerateImpulse();
    }
}
