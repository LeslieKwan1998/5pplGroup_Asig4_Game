using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    public bool lockJump;
    public bool lockSuperJump;

    public bool lockSpatuala;
    public bool lockHit;
    public bool lockCharge;
    // Start is called before the first frame update
    bool configed = false;
    CenterController centerController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!configed)
        {
            centerController = this.gameObject.GetComponent<CenterController>();
            configed = true;
            if (lockJump)
                centerController.basicMoveMent.setJlock(true);
            if (lockSuperJump)
                centerController.basicMoveMent.setKlock(true);
            if (lockSpatuala)
                centerController.rotateArm.disableAbility();
            if (lockHit)
                centerController.landHit.disableAbility();
            if (lockCharge)
                centerController.chargeArm.disableAbility();


        }
    }
}
