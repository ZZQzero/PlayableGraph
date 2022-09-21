using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class AnimRandomSelectTest : MonoBehaviour
{
    public AnimationClip[] clips;
    private PlayableGraph _playableGraph;
    private AnimRandomSelect anim;
    private int oldIndex;
    void Start()
    {
        _playableGraph = PlayableGraph.Create();

        anim = new AnimRandomSelect(_playableGraph);
        foreach (var clip in clips)
        {
            anim.AddInput(AnimationClipPlayable.Create(_playableGraph,clip));
        }
        AnimHelp.SetOutPut(_playableGraph,GetComponent<Animator>(),anim);
        var index = anim.Select();
        AnimHelp.Start(_playableGraph);
        oldIndex = index;
        Debug.LogError(index);
    }


    private void OnDisable()
    {
        _playableGraph.Destroy();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (anim.enable)
            {
                anim.Disable();
            }
            else
            {
                anim.Enable();
            }
        }
    }
}
