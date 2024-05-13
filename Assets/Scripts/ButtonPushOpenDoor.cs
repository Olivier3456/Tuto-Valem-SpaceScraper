using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushOpenDoor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string boolName = "Open";

    private void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ToggleDoorOpen());


    }

    public void ToggleDoorOpen()
    {
        Debug.Log("ToggleDoorOpen called");

        bool isOpen = animator.GetBool(boolName);

        Debug.Log($"isOpen = {isOpen}");

        animator.SetBool(boolName, !isOpen);
    }
}
