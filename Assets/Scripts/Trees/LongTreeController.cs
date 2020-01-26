using System.Collections.Generic;
using Constants;
using Mining;
using UnityEditor;
using UnityEngine;

public class LongTreeController : MonoBehaviour
{
    private static readonly int AnimationTime = Animator.StringToHash("Time");

    public int size = 1;

    public GameObject Top;
    public GameObject Middle;
    public GameObject Bottom;
    public GameObject Stump;
    public GameObject LeavesParticles;

    public GameObject drop;
    public int dropQuantity = 1;
    
    private List<GameObject> _leaves = new List<GameObject>();
    private List<ParticleSystem> _leavesParticles = new List<ParticleSystem>();
    private Animator[] _animators;
    private BoxCollider2D _leavesCollider;

    private void Start()
    {
        Stump.SetActive(false);
        Bottom.SetActive(true);

        var mineableBottom = Bottom.GetComponent<MineableController>();
        mineableBottom.Destroyed += DestroyTree;
        mineableBottom.Damaged += DamageLeaves;

        GenerateLeaves();
        CreateLeavesCollider();
        PrepareAnimators();
    }

    private void PrepareAnimators()
    {
        _animators = GetComponentsInChildren<Animator>();
        foreach (var animator in _animators)
        {
            animator.speed = 0f;
        }
    }

    private void GenerateLeaves()
    {
        CreateLeaf(Top, transform.position + new Vector3(0, size, 0));
        for (var i = 1; i < size; i++)
        {
            CreateLeaf(Middle, transform.position + new Vector3(0, i, 0));
        }
    }

    private void CreateLeaf(GameObject prefab, Vector3 position)
    {
        var leaf = Instantiate(prefab, position, Quaternion.identity);
        leaf.transform.parent = transform;
        _leaves.Add(leaf);

        var effect = Instantiate(
            LeavesParticles,
            position,
            LeavesParticles.transform.rotation
        );
        effect.transform.parent = transform;
        _leavesParticles.Add(effect.GetComponent<ParticleSystem>());
    }

    private void CreateLeavesCollider()
    {
        _leavesCollider = GetComponent<BoxCollider2D>();
        if (_leavesCollider == null)
            return;
        _leavesCollider.size = new Vector2(1, size);
        _leavesCollider.offset = new Vector2(0, GetColliderOffset());
    }

    private void DamageLeaves(float durabilityPercentage)
    {
        _leavesParticles.ForEach(p =>
        {
            p.Clear();
            p.Play();
        });
        foreach (var animator in _animators)
        {
            animator.SetFloat(AnimationTime, 1 - durabilityPercentage);
        }
    }

    private void DestroyTree()
    {
        _leaves.ForEach(l =>
        {
            var item = Instantiate(drop, l.transform.position, Quaternion.identity);
            item.GetComponent<DropItemController>().qunatity = dropQuantity;
            Destroy(l);
        });
        ShowStump();
    }
    
    private void ShowStump()
    {
        Stump.SetActive(true);
    }

    private float GetColliderOffset()
    {
        return size / 2 + (size % 2 == 0 ? 0.5f : 1f);
    }

    private void OnDrawGizmos()
    {
        var transparency = .4f;
        var margins = .2f;
        Gizmos.color = Colors.Turquoise - new Color(0, 0, 0, 1 - transparency);
        Gizmos.DrawCube(
            transform.position + new Vector3(0, GetColliderOffset() - margins / 2, 0),
            new Vector3(1 - margins, size - margins, 0)
        );
    }
}