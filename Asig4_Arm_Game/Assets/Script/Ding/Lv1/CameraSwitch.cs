using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera cvm1;
    [SerializeField]
    CinemachineVirtualCamera bossCvm;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("cl");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("cl");
            cvm1.Priority = 0;
            bossCvm.Priority = 1;




        }
    }
    
   
}
