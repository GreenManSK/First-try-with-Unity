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

    private List<GameObject> _leaves = new List<GameObject>();
    private BoxCollider2D _leavesCollider;

    private void Start()
    {
        Stump.SetActive(false);
        Bottom.SetActive(true);

        Bottom.GetComponent<MineableController>().Destroyed += ShowStump;

        GenerateLeaves();
        CreateLeavesCollider();
    }

    private void GenerateLeaves()
    {
        var top = Instantiate(Top, transform.position + new Vector3(0, size, 0), Quaternion.identity);
        top.transform.parent = transform;
        _leaves.Add(top);
        for (var i = 1; i < size; i++)
        {
            var middle = Instantiate(Middle, transform.position + new Vector3(0, i, 0), Quaternion.identity);
            middle.transform.parent = transform;
            _leaves.Add(middle);
        }
    }

    private void CreateLeavesCollider()
    {
        _leavesCollider = GetComponent<BoxCollider2D>();
        if (_leavesCollider == null)
            return;
        _leavesCollider.size = new Vector2(1, size);
        _leavesCollider.offset = new Vector2(0, GetColliderOffset());
    }

    private float GetColliderOffset()
    {
        return size / 2 + (size % 2 == 0 ? 0.5f : 1f);
    }

    private void ShowStump()
    {
        _leaves.ForEach(Destroy);
        Stump.SetActive(true);
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