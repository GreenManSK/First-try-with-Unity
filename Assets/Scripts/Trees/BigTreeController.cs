using System.Collections.Generic;
using Constants;
using Mining;
using UnityEngine;

public class BigTreeController : MonoBehaviour
{
    private static readonly int AnimationTime = Animator.StringToHash("Time");

    public int widht;
    public int height;

    public GameObject TopR;
    public GameObject TopM;
    public GameObject TopL;
    public GameObject MiddleR;
    public GameObject MiddleM;
    public GameObject MiddleL;
    public GameObject BottomR;
    public GameObject BottomM;
    public GameObject BottomL;
    public GameObject StumpR;
    public GameObject StumpM;
    public GameObject StumpL;

    public GameObject mineable;

    public GameObject LeavesParticles;

    public GameObject drop;
    public int dropQuantity = 1;
    
    private GameObject[,] _leavesBlocks; // height, width
    private readonly List<GameObject> _stumpBlocks = new List<GameObject>();
    private BoxCollider2D _leavesCollider;
    private readonly List<ParticleSystem> _leavesParticles = new List<ParticleSystem>();
    private readonly List<Animator> _animators = new List<Animator>();

    private void Start()
    {
        Generate();
        PrepareMineable();
        CreateLeavesCollider();
    }

    private void PrepareMineable()
    {
        var mineableController = mineable.GetComponent<MineableController>();
        mineableController.SetMaxDurability(mineableController.maxDurability * (widht + 1), true);
        mineableController.Damaged += DropLeaves;
        mineableController.Destroyed += Destroyed;
    }

    private void Generate()
    {
        GenerateBottom();
        GenerateStump();
        GenerateLeaves();
    }

    private void CreateLeavesCollider()
    {
        _leavesCollider = GetComponent<BoxCollider2D>();
        if (_leavesCollider == null)
            return;
        _leavesCollider.size = new Vector2(widht + 2, height + 1);
        _leavesCollider.offset = GetColliderPosition();
    }

    private void GenerateLeaves()
    {
        _leavesBlocks = new GameObject[height + 1, widht + 2];
        GenerateLeavesLayer(0, TopL, TopM, TopR);
        for (var i = 1; i <= height; i++)
        {
            GenerateLeavesLayer(i, MiddleL, MiddleM, MiddleR);
        }
    }

    private void GenerateLeavesLayer(int row, GameObject left, GameObject middle, GameObject right)
    {
        var transformHeight = height + 1 - row;
        _leavesBlocks[row, 0] = CreateLeafBlock(left, transform.position + new Vector3(0, transformHeight, 0));
        for (var i = 1; i <= widht; i++)
        {
            _leavesBlocks[row, i] = CreateLeafBlock(middle, transform.position + new Vector3(i, transformHeight, 0));
        }

        _leavesBlocks[row, widht + 1] =
            CreateLeafBlock(right, transform.position + new Vector3(widht + 1, transformHeight, 0));
    }

    private void GenerateBottom()
    {
        AddLeavesParticles(BottomL);
        _animators.Add(BottomL.GetComponent<Animator>());

        for (var i = 1; i <= widht; i++)
        {
            var block = CreateLeafBlock(BottomM, transform.position + new Vector3(i, 0, 0));
            block.transform.SetParent(mineable.transform, true);
        }

        var right = CreateLeafBlock(BottomR, transform.position + new Vector3(widht + 1, 0, 0));
        right.transform.SetParent(mineable.transform, true);
    }

    private void Destroyed()
    {
        _stumpBlocks.ForEach(s => s.SetActive(true));
        foreach (var leave in _leavesBlocks)
        {
            var item = Instantiate(drop, leave.transform.position, Quaternion.identity);
            item.transform.SetParent(transform, true);
            item.GetComponent<DropItemController>().quantity = dropQuantity;
            Destroy(leave);
        }
    }

    private void DropLeaves(float damage)
    {
        _animators.ForEach(a => a.SetFloat(AnimationTime, 1 - damage));
        _leavesParticles.ForEach(p =>
        {
            p.Clear();
            p.Play();
        });
    }

    private void GenerateStump()
    {
        _stumpBlocks.Add(StumpL);
        for (var i = 1; i <= widht; i++)
        {
            var block = CreateBlock(StumpM, transform.position + new Vector3(i, 0, 0));
            _stumpBlocks.Add(block);
        }

        var right = CreateBlock(StumpR, transform.position + new Vector3(widht + 1, 0, 0));
        _stumpBlocks.Add(right);
        _stumpBlocks.ForEach(s => s.SetActive(false));
    }

    private GameObject CreateLeafBlock(GameObject prefab, Vector3 position)
    {
        var leaf = CreateBlock(prefab, position);
        AddLeavesParticles(leaf);
        return leaf;
    }

    private void AddLeavesParticles(GameObject block)
    {
        var effect = Instantiate(
            LeavesParticles,
            block.transform.position,
            LeavesParticles.transform.rotation
        );
        effect.transform.SetParent(transform, true);
        _leavesParticles.Add(effect.GetComponent<ParticleSystem>());
    }

    private GameObject CreateBlock(GameObject prefab, Vector3 position)
    {
        var block = Instantiate(prefab, position, Quaternion.identity);
        block.transform.SetParent(transform, true);
        var animator = block.GetComponent<Animator>();
        if (animator != null)
            _animators.Add(animator);
        return block;
    }

    private Vector2 GetColliderPosition()
    {
        return new Vector2(
            widht / 2 + ((widht + 2) % 2 == 0 ? 0.5f : 1f),
            (height + 1) / 2 + ((height + 1) % 2 == 0 ? 0.5f : 1f)
        );
    }

    private void OnDrawGizmos()
    {
        var transparency = .4f;
        var margins = .2f;
        Gizmos.color = Colors.Turquoise - new Color(0, 0, 0, 1 - transparency);
        Gizmos.DrawCube(
            transform.position + (Vector3) GetColliderPosition() + new Vector3(0, -margins / 2, 0),
            new Vector3(widht + 2 - margins, height + 1 - margins, 0)
        );

        Gizmos.color = Colors.Orange - new Color(0, 0, 0, 1 - transparency);
        Gizmos.DrawCube(
            transform.position + new Vector3((widht + 1 - margins) / 2 + .5f, margins / 2, 0),
            new Vector3(widht + 1 - margins, 1 - margins, 0)
        );
    }
}