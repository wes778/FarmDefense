using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    private NavMeshAgent meshAgent;
    private Vector3 offset = new Vector3(0,0,-1.5f);

    private void Awake()

    {
        meshAgent = GetComponent<NavMeshAgent>();
    }
  

    public bool MoveToTarget(Transform target)
    {
        meshAgent.SetDestination(target.position);
        
        return HasReachedDestionation();
    }

    public bool HasReachedDestionation()
    {
        Debug.Log(meshAgent.remainingDistance);
        Debug.Log(meshAgent.hasPath);
        bool reachedOrNot = false;
        if (meshAgent.hasPath)
        {
            if (meshAgent.remainingDistance <= meshAgent.stoppingDistance)
            {
                reachedOrNot = true;
            }
        }
        
            /*if (!meshAgent.hasPath || meshAgent.velocity.sqrMagnitude == 0f)
            {

                //reachedOrNot = true;
            }
        }*/
            return reachedOrNot;    
        
    }

    
}
