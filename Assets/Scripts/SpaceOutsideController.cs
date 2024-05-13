using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SpaceOutsideController : MonoBehaviour
{
    [SerializeField] private XRLever lever;

    // (XRKnob est le volant, ou la wheel.)
    [SerializeField] private XRKnob knob;

    [SerializeField] private float forwardSpeed;
    [SerializeField] private float sideSpeed;



    void Update()
    {
        float forwardVelocity = forwardSpeed * (lever.value ? 1 : 0);  // (lever.value est un bool)

        // (Pour que ça fonctionne, dans Unity, nous avons réglé les valeurs min et max du knob à 0 et 1.
        // Comme ça, si le volant est au milieu de sa rotation (= 0.5), avec ce Mathf.Lerp, nous obtiendrons 0.)
        float sideVelocity = sideSpeed * (lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, knob.value);

        Vector3 velocity = new Vector3(sideVelocity, 0, forwardVelocity);
        transform.position += velocity * Time.deltaTime;
    }
}
