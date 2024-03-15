using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("tchirmvkoasjdkgsmd");
        Destroy(other.gameObject);
    }
}
