using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Destenation : MonoBehaviour
{
    [SerializeField]
    int nextLevelNumber;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            SceneManager.LoadScene(nextLevelNumber);
        }
    }
}
