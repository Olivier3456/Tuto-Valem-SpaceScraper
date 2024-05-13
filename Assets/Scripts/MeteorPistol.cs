using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform shootSource;
    [SerializeField] private float distance = 10;

    private bool rayActivate = false;

    private void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());
    }

    private void Update()
    {
        if (rayActivate)
        {
            RaycastCheck();
        }
    }


    private void StartShoot()
    {
        particles.Play();
        rayActivate = true;
    }

    private void StopShoot()
    {
        // Pour stopper toutes les particules spawnées :
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;
    }

    private void RaycastCheck()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, out hit, distance, layerMask);

        if (hasHit)
        {
            if (hit.transform.TryGetComponent(out Breakable breakable))
            {
                breakable.Break();
            }
            // Remplace :
            //hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
