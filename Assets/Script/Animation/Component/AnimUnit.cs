using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class AnimUnit : AnimBehavior
{
    public AnimationClipPlayable animClipPlayable;
    
    public AnimUnit(PlayableGraph graph,AnimationClip clip) : base(graph)
    {
        animClipPlayable = AnimationClipPlayable.Create(graph, clip);
        adapterPlayable.AddInput(animClipPlayable,0, 1);
        Disable();
    }

    public override void Enable()
    {
        base.Enable();
        animClipPlayable.SetTime(0f);
        adapterPlayable.SetTime(0f);
        adapterPlayable.Play();
        animClipPlayable.Play();
    }

    public override void Disable()
    {
        base.Disable();
        animClipPlayable.Pause();
        adapterPlayable.Pause();
    }
}
