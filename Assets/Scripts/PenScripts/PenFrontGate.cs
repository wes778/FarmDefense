using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenFrontGate : MonoBehaviour
{
    private CowPenController penController;
    private void Awake()
    {
        penController = GetComponentInParent<CowPenController>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        print("Ello");
        if(other.CompareTag("Player"))
        {
            penController.OpenFrontGate();
        }
    }
}
