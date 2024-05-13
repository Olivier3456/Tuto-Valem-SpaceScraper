using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlaySteps : MonoBehaviour
{
    private PlayableDirector director;
    [SerializeField] private List<Step> steps;

    [Serializable]
    public class Step
    {
        public string name;
        public float time;
        public bool hasPlayed = false;
    }


    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    public void PlayStepIndex(int index)
    {
        Step step = steps[index];
        if (!step.hasPlayed)
        {
            step.hasPlayed = true;
            director.Stop();
            director.time = step.time;
            director.Play();
        }
    }
}
