using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class AnimUnitTest : MonoBehaviour
{
    private PlayableGraph _graph;
    private AnimUnit _animUnit;
    public AnimationClip clip;
    void Start()
    {
        _graph = PlayableGraph.Create();
        _animUnit = new AnimUnit(_graph, clip);
      
        
        /*var animOutPut = AnimationPlayableOutput.Create(_graph, "Animation", GetComponent<Animator>());
        animOutPut.SetSourcePlayable(root.GetAnimAdapterPlayable());*/
        
        AnimHelp.SetOutPut(_graph,GetComponent<Animator>(),_animUnit);
        AnimHelp.Start(_graph);
        // _graph.Play();
        // //_animUnit.Enable();
        // root.Enable();
    }

    private void OnDisable()
    {
        _graph.Destroy();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_animUnit.enable)
            {
                _animUnit.Enable();
            }
            else
            {
                _animUnit.Disable();
            }
        }
        
    }
}
