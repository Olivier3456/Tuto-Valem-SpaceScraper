using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabbingHandModel : MonoBehaviour
{
    [SerializeField] private GameObject leftHandModel;
    [SerializeField] private GameObject rightHandModel;

    private void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);
    }

    public void HideGrabbingHand(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Left Hand"))
        {
            leftHandModel.SetActive(false);
        }
        else
        {
            rightHandModel.SetActive(false);
        }
    }

    public void ShowGrabbingHand(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Left Hand"))
        {
            leftHandModel.SetActive(true);
        }
        else
        {
            rightHandModel.SetActive(true);
        }
    }
}
