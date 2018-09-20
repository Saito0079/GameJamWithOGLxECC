using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour {

    public bool isOpen = false;
    Renderer rend;
    Animator animator;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        /*
		if (!isOpen)
        {
            // Set the main Color of the Material to red
            rend.material.SetColor("_Color", Color.red);
            animator.SetTrigger("CloseDoor");
        } else
        {
            // Set the main Color of the Material to green
            rend.material.SetColor("_Color", Color.green);
            animator.SetTrigger("OpenDoor");
        }
        */
	}

    public void operateDoor()
    {
        if (isOpen)
        {
            // set the door as closed and enable collider so player can't pass
            isOpen = false;
            animator.SetBool("CloseDoor", true);
            animator.SetBool("OpenDoor", false);
        } else
        {
            // set the door open and disable colliders so player passes through
            isOpen = true;
            animator.SetBool("CloseDoor", false);
            animator.SetBool("OpenDoor", true);
        }
    }

    public void closeDoor()
    {
        isOpen = false;
    }
}
