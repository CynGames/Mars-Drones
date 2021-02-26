using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnimationHandler : MonoBehaviour
{
    public static TransitionAnimationHandler Instance;

    public bool isPlayingAnimation;
    public bool playOnStart = true;

    [SerializeField] Animator transitionAnimator = null;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    private void Start()
    {
        if(playOnStart) Opening();
    }

    public void Closing()
    {
        transitionAnimator.SetTrigger("Closing");
    }

    public void Opening()
    {
        transitionAnimator.SetTrigger("Opening");
    }

    public void TransitionStart()
    {
        isPlayingAnimation = true;
    }

    public void TransitionDone()
    {
        isPlayingAnimation = false;
    }
}
