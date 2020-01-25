using System.Collections.Generic;
using Constants;
using Mining;
using UnityEditor;
using UnityEngine;

public class LongTreeController : MonoBehaviour
{
    public int size = 1;

    public GameObject Top;
    public GameObject Middle;
    public GameObject Bottom;
    public GameObject Stump;
    public GameObject LeavesParticles;

    private List<GameObject> _leaves = new List<GameObject>();
    private List<ParticleSystem> _leavesParticles = new List<ParticleSystem>();
    private BoxCollider2D _leavesCollider;

    private void Start()
    {
        Stump.SetActive(false);
        Bottom.SetActive(true);

        var mineableBottom = Bottom.GetComponent<MineableController>();
        mineableBottom.Destroyed += ShowStump;
        mineableBottom.Damaged += DamageLeaves;

        GenerateLeaves();
        CreateLeavesCollider();
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
    }

    private void ShowStump()
    {
        _leaves.ForEach(Destroy);
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