using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggChasingState : State
{
    EnemyController enemyController;

    public EggChasingState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public override void beginFunc()
    {
    
    }
    public override void excute()
    {
        base.excute();
        enemyController.moveToTarget();


    }
    public override State tryTrans()
    {
        if (!enemyController.state_hasEnemyInGuardRange())
            return new EggGuardingState(enemyController);
        if (enemyController.state_hasEnemeyInAttackRange()&&enemyController.state_readyToAttack())
            return new EggAttackingState(enemyController);
        if (enemyController.state_isHurt())
            return new EggBeHurtState(enemyController);
        return this;
    }
}
