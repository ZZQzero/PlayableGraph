using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class AnimRandomSelect : AnimBehavior
{
    public AnimationMixerPlayable mixerPlayable;

    public int currentIndex;
    public int clipCount;
    
    public AnimRandomSelect(PlayableGraph graph) : base(graph)
    {
        mixerPlayable = AnimationMixerPlayable.Create(graph);
        adapterPlayable.AddInput(mixerPlayable, 0, 1);
        currentIndex = -1;
    }


    public override void AddInput(Playable playable)
    {
        mixerPlayable.AddInput(playable, 0);
        clipCount++;
    }

    public override void Enable()
    {
        base.Enable();
        if (currentIndex < 0 || currentIndex >= clipCount)
        {
            return;
        }
        
        AnimHelp.Enable(mixerPlayable,currentIndex);
        mixerPlayable.SetInputWeight(currentIndex,1);
        adapterPlayable.SetTime(0);
        mixerPlayable.SetTime(0);
        mixerPlayable.Play();
        adapterPlayable.Play();

    }

    public override void Disable()
    {
        base.Disable();
        if (currentIndex < 0 || currentIndex >= clipCount)
        {
            return;
        }
        AnimHelp.Disable(mixerPlayable,currentIndex);
        mixerPlayable.SetInputWeight(currentIndex,0);
        adapterPlayable.Pause();
        mixerPlayable.Pause();
        currentIndex = -1;
    }

    public int Select()
    {
        currentIndex = Mathf.FloorToInt(Random.Range(0, clipCount));
        return currentIndex;
    }
}
