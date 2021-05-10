using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggAttackingState : State
{
    EnemyController enemyController;

    bool flag = false;
    public EggAttackingState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public override void beginFunc()
    {

      
        enemyController.ani.Play("PreAttack");
    }

    public override void excute()
    {
        base.excute();
        AnimatorStateInfo info = enemyController.ani.GetCurrentAnimatorStateInfo(0);
        // 判断动画是否播放完成
        if (info.normalizedTime >= 0.8f && flag == false) 
        {
            enemyController.attack();
            flag = true;
        }
    }
    public override State tryTrans()
    {

       
        AnimatorStateInfo info = enemyController.ani.GetCurrentAnimatorStateInfo(0);
        // 判断动画是否播放完成
        if (info.normalizedTime >= 1.0f)
        {
          
            return new EggGuardingState(enemyController);
        }
        if (enemyController.state_isHurt())
            return new EggBeHurtState(enemyController);
        return this;
    }
}
