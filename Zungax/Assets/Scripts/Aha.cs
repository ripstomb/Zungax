using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aha : MonoBehaviour
{
    [SerializeField]
    private GameObject chimbada;
    public void AparecerMonda()
    {
        chimbada.SetActive(true);
    }
}
