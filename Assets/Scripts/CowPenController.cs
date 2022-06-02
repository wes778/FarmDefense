using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowPenController : MonoBehaviour
{
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenFrontGate()
    {
        animator.Play("PenOpen");
    }

    public void CloseFrontGate()
    {
        animator.Play("PenClose");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            animator.Play("PenOpen");
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            animator.Play("PenClose");
        }
    }
}
