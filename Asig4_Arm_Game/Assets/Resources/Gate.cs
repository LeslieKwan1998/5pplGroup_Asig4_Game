using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    EnemyController[] enemys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var k in enemys)
        {
            if (k != null)
                return;
        }
        openGate();

    }
    void openGate()
    {
        Animator ani = this.GetComponent<Animator>();
        ani.Play("Gate@Open");

    }
}
