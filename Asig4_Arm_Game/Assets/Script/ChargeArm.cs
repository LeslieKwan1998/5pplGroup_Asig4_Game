using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeArm : MonoBehaviour, IChargeArm
{
    bool _isEnable = false;
    public void charge()
    {
     
    }

    public void disableAbility()
    {
        _isEnable = false;
    }

    public void enableAbility(CenterController centerController)
    {
        _isEnable = true;
    }

    public void enableAbility()
    {
        _isEnable = true;
    }

    public bool isEnabled()
    {
        return _isEnable;
    }

    public void release()
    {
      
    }
}
