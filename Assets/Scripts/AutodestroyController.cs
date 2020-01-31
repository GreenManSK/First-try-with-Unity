using UnityEngine;

public class AutodestroyController : MonoBehaviour
{
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
