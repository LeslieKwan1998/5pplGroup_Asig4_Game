using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggGuardingState : State
{
    EnemyController enemyController;

    public EggGuardingState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public override void beginFunc()
    {
        enemyController.StartCoroutine("guardProcess");
    }

    public override void leaveState()
    {
        base.leaveState();
        enemyController.StopCoroutine("guardProcess");
    }
    public override State tryTrans()
    {
       if(enemyController.state_hasEnemyInGuardRange())
        {
            return new EggChasingState(enemyController);
        }
        if (enemyController.state_isHurt())
            return new EggBeHurtState(enemyController);
        return this;
    }
   IEnumerator test()
    {
        yield return new WaitForSeconds(1f);
    }

}
