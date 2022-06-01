using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    private NavMeshAgent meshAgent;


    private void Awake()

    {
        meshAgent = GetComponent<NavMeshAgent>();
    }


    public void MoveToTarget(Transform target)
    {
        meshAgent.SetDestination(target.position); 
    }

    public bool HasAPath()
    {
        return meshAgent.hasPath;
    }

    public bool HasReachedDestionation()
    {

        
        
        bool reachedOrNot = false;
        if (meshAgent.hasPath)
        {
            
            if (meshAgent.remainingDistance <= meshAgent.stoppingDistance && meshAgent.velocity == Vector3.zero)
            {

                reachedOrNot = true;
                meshAgent.ResetPath();
            }
        }
        return reachedOrNot;

    }


}
