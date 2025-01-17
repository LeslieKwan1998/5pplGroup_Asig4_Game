﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBasicMoveMent :IAbility,iActivateAbility
{
    void moveLeft();
    void moveRight();

    void slowMoveLeft();
    void slowMoveRight();
    void Jump();
    void SuperJump();
    void SmallJump();
    void forceJump();

    bool getJlocked();
    bool getKlocked();
    void setJlock(bool value);
    void setKlock(bool value);
}
