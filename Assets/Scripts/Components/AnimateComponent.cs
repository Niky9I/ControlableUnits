using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateComponent : MonoBehaviour
{
    private StateComponent _state;
    private Animator _animator;
    private string _nowAnimation;

    void Start()
    {
        _state = gameObject.GetComponent<StateComponent>();
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (_nowAnimation == _state.state.ToString()) return;
        _nowAnimation = _state.state.ToString();
        _animator.SetTrigger(_nowAnimation);
    }
}
