using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBasicMoveMent :IAbility,iActivateAbility
{
    void moveLeft();
    void moveRight();
    void Jump();
    void SuperJump();
    void SmallJump();
}
