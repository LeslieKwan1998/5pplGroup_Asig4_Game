using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Notifier : MonoBehaviour
{
    string notice;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
  
       
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo info = ani.GetCurrentAnimatorStateInfo(0);
        // 判断动画是否播放完成
        if (info.normalizedTime >= 1.0f)
            Destroy(this.gameObject);

    }

    public void beCreat(string s ,Color color)
    {
        ani = this.GetComponent<Animator>();
        this.notice = s;
        Text text = this.GetComponentInChildren<Text>();
        text.text = notice;
        text.color = color;

        ani.Play("NotificeAni");
    }
    public void showHit(string s,Color color,AttackPower attackPower)
    {
        ani = this.GetComponent<Animator>();
        this.notice = s;
        Text text = this.GetComponentInChildren<Text>();
        text.text = notice;
        text.color = color;
        switch (attackPower)
        {
            case AttackPower.pa:
                ani.Play("SmallHit");
                break;
            case AttackPower.boom:
                ani.Play("MidHit");
                break;
            case AttackPower.dong:
                ani.Play("MidHit");
                break;
        }
  

    }

   
}
