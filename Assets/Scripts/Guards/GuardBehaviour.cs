using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehaviour : MonoBehaviour
{
    public Guard guard { get; private set; }
    public float duration;
    public float HomeDuration;

    private void Awake()
    {
        this.guard = GetComponent<Guard>();
    }

    public void Enable()
    {
        Enable(this.duration);
    }

    public void HomeEnable()
    {
        HomeDuration = duration;
        HomeEnable(HomeDuration);
    }

    public virtual void Enable(float duration)
    {
        this.enabled = true;
        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }

    public virtual void HomeEnable(float HomeDuration)
    {
        this.enabled = true;
        CancelInvoke();
        Invoke(nameof(Disable), duration);
        //HomeDuration = duration;
    }
    public virtual void Disable()
    {
        this.enabled = false;
        CancelInvoke();
    }

}
