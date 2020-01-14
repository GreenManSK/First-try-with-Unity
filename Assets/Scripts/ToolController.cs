using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    private static readonly int StabAnimationTrigger = Animator.StringToHash("Stab");
    private static readonly int SwingAnimationTrigger = Animator.StringToHash("Swing");

    public delegate void DestroyDelegate();

    public event DestroyDelegate destroyed;
    
    private Animator _animator;

    public void Stab()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(StabAnimationTrigger);
    }
    
    public void Swing()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(SwingAnimationTrigger);
    }

    public void OnFinish()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Constants.Layers.Destroyable))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        destroyed?.Invoke();
    }
}
