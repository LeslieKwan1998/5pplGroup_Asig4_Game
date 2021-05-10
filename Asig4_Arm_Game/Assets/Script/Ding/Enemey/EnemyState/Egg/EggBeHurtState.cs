using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBeHurtState : State
{
    EnemyController enemyController;

    public EggBeHurtState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public override void beginFunc()
    {
        Animator ani = enemyController.GetComponent<Animator>();
        ani.Play("BeHurt");
    }

    public override State tryTrans()
    {
        base.excute();
        AnimatorStateInfo info = enemyController.ani.GetCurrentAnimatorStateInfo(0);
        // 判断动画是否播放完成
        if (info.normalizedTime >= 1)
        {

            return new EggGuardingState(enemyController);
        }
        return this;
    }
}
