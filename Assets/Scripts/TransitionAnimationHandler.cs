using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnimationHandler : MonoBehaviour
{
    public static TransitionAnimationHandler Instance;

    public bool isPlayingAnimation;

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
        Opening();
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
