using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{

    void disableAbility(); // This fuction will be called  when  player lose this ability;
    void enableAbility(CenterController centerController); // This fuction will be called  when player get this ability

    void enableAbility();
    bool isEnabled();

}
public interface iActivateAbility
{
    bool isActivate();
    void activate();
    void deactivate();
}