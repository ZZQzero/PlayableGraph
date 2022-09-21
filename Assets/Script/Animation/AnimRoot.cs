using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimRoot : AnimBehavior
{
    public AnimRoot(PlayableGraph graph) : base(graph)
    {

    }

    public override void AddInput(Playable playable)
    {
        adapterPlayable.AddInput(playable, 0, 1);
    }

    public override void AddInput(AnimBehavior animBehavior)
    {
        adapterPlayable.AddInput(animBehavior.GetAnimAdapterPlayable(), 0, 1);
    }


    public override void Enable()
    {
        base.Enable();
        for (int i = 0; i < adapterPlayable.GetInputCount(); i++)
        {
            AnimHelp.Enable(adapterPlayable.GetInput(i));
        }
        adapterPlayable.SetTime(0f);
        adapterPlayable.Play();
    }

    public override void Disable()
    {
        base.Disable();
        for (int i = 0; i < adapterPlayable.GetInputCount(); i++)
        {
            AnimHelp.Disable(adapterPlayable.GetInput(i));
        }
        adapterPlayable.Pause();
    }
}
