using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimAdapter : PlayableBehaviour
{
    private AnimBehavior _animBehavior;

    public void Init(AnimBehavior animBehavior)
    {
        _animBehavior = animBehavior;
    }

    public void Enable()
    {
        _animBehavior?.Enable();
    }

    public void Disable()
    {
        _animBehavior?.Disable();
    }

    public override void PrepareFrame(Playable playable, FrameData info)
    {
        _animBehavior.Execute(playable,info);
    }
}
