using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam : MonoBehaviour
{
    Animator ani;
    bool isPlayeing = false;
    [SerializeField]
    float refreshTime;
    float dispeatTime = 0.4f;

  
    public float refreshTimer = 0;
    Vector3 scaleBuffer;
    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void beHit(CenterController centerController)
    {
        if (isPlayeing)
            return;

        if (centerController.JamStateRestTime > 0.2f)
        {
            centerController.JamStateRestTime = centerController.JamStateTime;
        }
        else
        { centerController.changeToJamTrigger = true; }
        isPlayeing = true;
        StartCoroutine(disPearPorcess());
  
    }
    IEnumerator disPearPorcess()
    {
   
        ani.Play("Jam@Break");
     
        yield return new WaitForSeconds(dispeatTime);

        scaleBuffer = this.gameObject.transform.localScale;
        this.gameObject.transform.localScale = Vector2.zero;
        yield return new WaitForSeconds(refreshTime);

        refresh();
    }

    void refresh()
    {
      
        ani.Play("Jam@Normal");
        this.gameObject.transform.localScale = scaleBuffer;
        isPlayeing= false;

    }
}
