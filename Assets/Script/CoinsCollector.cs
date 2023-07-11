using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    [HideInInspector]
    public int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cube_Collectable")) //Collecting cubes
        {
            Destroy(other.gameObject);
            count++;
        }
    }
}
