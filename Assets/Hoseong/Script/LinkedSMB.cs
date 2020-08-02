using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LinkedSMB<TMonoBehaviour> : StateMachineBehaviour where TMonoBehaviour : MonoBehaviour
{
    protected TMonoBehaviour m_MonoBehaviour;

    public static void Initialise(Animator animator, TMonoBehaviour monoBehaviour)
    {
        LinkedSMB<TMonoBehaviour>[] linkedSMBs = animator.GetBehaviours<LinkedSMB<TMonoBehaviour>>();

        for (int i = 0; i < linkedSMBs.Length; i++)
        {
            linkedSMBs[i].InternalInitialise(animator, monoBehaviour);
        }
    }

    protected void InternalInitialise(Animator animator, TMonoBehaviour monoBehaviour)
    {
        m_MonoBehaviour = monoBehaviour;
    }
}
