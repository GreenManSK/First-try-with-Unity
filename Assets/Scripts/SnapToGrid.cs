using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
#if UNITY_EDITOR
    public bool snapToGrid = true;
    public float snapValue = 1.0f;
 
    public bool sizeToGrid;
    public float sizeValue = 1.0f;
#endif
}
