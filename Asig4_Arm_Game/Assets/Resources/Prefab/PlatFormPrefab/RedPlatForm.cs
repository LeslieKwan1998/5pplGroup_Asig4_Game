using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatForm : MonoBehaviour
{
    [SerializeField]
    PlayerDetector playerDetector;
    bool isTriggered = false;
    public float disapearTime =3f;
    public float refreshTime = 2f;
    Vector2 scaleBuffer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetector.isTriggered && !isTriggered)
        {
            isTriggered = true;
            StartCoroutine(disPearPorcess());
        }
    }
    IEnumerator disPearPorcess()
    {
        Animator ani = this.GetComponent<Animator>();
        ani.Play("PlatForm@BeforeDisapear");
        
        yield return new WaitForSeconds(disapearTime);

        scaleBuffer = this.gameObject.transform.localScale;
        this.gameObject.transform.localScale = Vector2.zero;
        yield return new WaitForSeconds(refreshTime);

        refresh();
    }

    void refresh()
    {
        Animator ani = this.GetComponent<Animator>();
        ani.Play("PlatForm@Idle");
        this.gameObject.transform.localScale = scaleBuffer;
        isTriggered = false;
        playerDetector.isTriggered = false;
    }
}
