using UnityEngine;

public class PowerBarController : MonoBehaviour
{
    public GameObject greenBar;
    public GameObject redBar;
    public int greens;
    public int reds;

    private GameObject[] _bars;

    private void Start()
    {
        _bars = new GameObject[greens + reds];
        var barWidth = greenBar.GetComponent<RectTransform>()?.rect.width ?? 0f;
        var positionMove = 0f;
        for (var i = 0; i < greens; i++)
        {
            _bars[i] = CreateBar(greenBar, transform.position + Vector3.right * positionMove);
            positionMove += 1.5f * barWidth;
        }
        for (var i = 0; i < reds; i++)
        {
            _bars[greens + i] = CreateBar(redBar, transform.position + Vector3.right * positionMove);
            positionMove += 1.5f * barWidth;
        }
    }

    private GameObject CreateBar(GameObject prefab, Vector3 position)
    {
        var gameObject = Instantiate(prefab, position, Quaternion.identity);
        gameObject.transform.SetParent(transform);
        return gameObject;
    }
}