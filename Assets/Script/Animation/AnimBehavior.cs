using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public abstract class AnimBehavior
{

    protected Playable adapterPlayable;

    public AnimBehavior()
    {
        
    }
    public AnimBehavior(PlayableGraph playableGraph)
    {
        adapterPlayable = ScriptPlayable<AnimAdapter>.Create(playableGraph);
        ((ScriptPlayable<AnimAdapter>)adapterPlayable).GetBehaviour().Init(this);
    }
    public bool enable { get; protected set; }

    public virtual void Enable()
    {
        enable = true;
    }

    public virtual void Disable()
    {
        enable = false;
    }

    public void Execute(Playable playable, FrameData info)
    {
        if (!enable)
        {
            return;
        }
    }

    public virtual void AddInput(Playable playable)
    {
        
    }

    public virtual void AddInput(AnimBehavior animBehavior)
    {
        
    }

    public Playable GetAnimAdapterPlayable()
    {
        return adapterPlayable;
    }
}
