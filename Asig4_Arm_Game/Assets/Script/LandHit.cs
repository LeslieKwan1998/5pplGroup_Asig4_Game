using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LandHit : MonoBehaviour, ILandHit
{
    bool _isEnable;
    IRotateArm rotateArm;
    ArmController armController;
    CenterController centerController;
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
        this.centerController = centerController;
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
        float basef = 10;
        //if (rotateTime >= 0.5)
        //    basef = 5;
        //if (rotateTime >= 0.7)
        //    basef = 10;
        //if (rotateTime >= 0.8)
        //    basef = 20;
        //if(rotateTime >= 0.9)
        //    basef = 30;
        //if (rotateTime >= 1)
        //    basef = 50;
        //if (rotateTime >= 1.1)
        //    basef = 70;
        //if (rotateTime >= 1.2)
        //    basef = 90;
        //if (rotateTime >= 1.3)
        //    basef = 110;
        //if (rotateTime >= 1.4)
        //    basef = 130;

        float booMPower = rotateTime * rotateTime *basef + 0.2f  ;
        AttackPower attackPower = AttackPower.pa;
        if (booMPower >= 6.7f)
        {
            attackPower = AttackPower.boom;
            centerController.showNotify("DOOM", Color.red, attackPower);
        }
        else if (booMPower > 3.8f)
        {
            attackPower = AttackPower.dong;
            centerController.showNotify("Dong", Color.yellow,attackPower );
        }
        else
        {
            attackPower = AttackPower.pa;
            centerController.showNotify("Pa", Color.white, attackPower);
        }



        Debug.Log("Roteta" + rotateTime * rotateTime *basef+ "velo " );
        GameObject a = Instantiate(BoomEFprefab, armController.getHitPos(),Quaternion.identity);
        a.transform.localScale *= 1 + rotateTime*2;
        a.GetComponent<BoomEF>().beCreat(attackPower);
        CinemachineCollisionImpulseSource cs = this.GetComponent<CinemachineCollisionImpulseSource>();
        cs.m_ImpulseDefinition.m_AmplitudeGain =booMPower;
        cs.GenerateImpulse();
       


    }
}
