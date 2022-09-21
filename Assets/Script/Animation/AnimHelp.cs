using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class AnimHelp
{
    public static void Enable(Playable playable)
    {
        var adapter = GetAdapter(playable);
        if (adapter != null)
        {
            adapter.Enable();
        }
    }

    public static void Enable(AnimationMixerPlayable mixerPlayable,int index)
    {
        Enable(mixerPlayable.GetInput(index));
    }


    public static void Disable(Playable playable)
    {
        var adapter = GetAdapter(playable);
        if (adapter != null)
        {
            adapter.Disable();
        }
    }
    
    public static void Disable(AnimationMixerPlayable mixerPlayable,int index)
    {
        Disable(mixerPlayable.GetInput(index));
    }
    public static AnimAdapter GetAdapter(Playable playable)
    {
        if (typeof(AnimAdapter).IsAssignableFrom(playable.GetPlayableType()))
        {
            return ((ScriptPlayable<AnimAdapter>)playable).GetBehaviour();
        }
        return null;
    }

    public static void SetOutPut(PlayableGraph graph,Animator animator,AnimBehavior behavior)
    {
        var root = new AnimRoot(graph);
        root.AddInput(behavior);
        var animOutPut = AnimationPlayableOutput.Create(graph, "Animation", animator);
        animOutPut.SetSourcePlayable(root.GetAnimAdapterPlayable());
    }

    public static void Start(PlayableGraph graph,AnimBehavior behavior)
    {
        graph.Play();
        behavior.Enable();
    }

    public static void Start(PlayableGraph graph)
    {
        graph.Play();
        GetAdapter(graph.GetOutputByType<AnimationPlayableOutput>(0).GetSourcePlayable()).Enable();
    }
}
