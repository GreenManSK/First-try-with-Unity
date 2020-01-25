using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTreeController : MonoBehaviour
{
    public int widht = 0;
    public int height = 0;

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

    private GameObject[,] _leavesBlocks;
    private List<GameObject> _bottomBlocks = new List<GameObject>();
    private List<GameObject> _stumpBlocks = new List<GameObject>();
    private BoxCollider2D _leavesCollider;

    private void Start()
    {
        Generate();
        // Create 2D Collider 
    }

    private void Generate()
    {
        GenerateBottom();
        GenerateStump();
        GenerateLeaves();
        CreateLeavesCollider();
    }

    private void CreateLeavesCollider()
    {
        _leavesCollider = GetComponent<BoxCollider2D>();
        if (_leavesCollider == null)
            return;
        _leavesCollider.size = new Vector2(widht + 2, height + 1);
        _leavesCollider.offset = new Vector2(
            widht / 2 + ((widht + 2) % 2 == 0 ? 0.5f : 1f),
            (height + 1) / 2 + ((height + 1) % 2 == 0 ? 0.5f : 1f)
        );
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
        _leavesBlocks[row, 0] = CreateBlock(left, transform.position + new Vector3(0, transformHeight, 0));
        for (var i = 1; i <= widht; i++)
        {
            _leavesBlocks[row, i] = CreateBlock(middle, transform.position + new Vector3(i, transformHeight, 0));
        }

        _leavesBlocks[row, widht + 1] =
            CreateBlock(right, transform.position + new Vector3(widht + 1, transformHeight, 0));
    }

    private void GenerateBottom()
    {
        _bottomBlocks.Add(BottomL);
        for (var i = 1; i <= widht; i++)
        {
            var block = CreateBlock(BottomM, transform.position + new Vector3(i, 0, 0));
            _bottomBlocks.Add(block);
        }

        var right = CreateBlock(BottomR, transform.position + new Vector3(widht + 1, 0, 0));
        _bottomBlocks.Add(right);
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

    private GameObject CreateBlock(GameObject prefab, Vector3 position)
    {
        var leaf = Instantiate(prefab, position, Quaternion.identity);
        leaf.transform.parent = transform;
        return leaf;
    }
}