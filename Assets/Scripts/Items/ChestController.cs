using Constants;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private static readonly int Open = Animator.StringToHash("Open");

    public AudioClip openSound;
    public GameObject drop;
    public int quantity = 1;

    private bool _open;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_open || !other.gameObject.CompareTag(Tags.Tool))
            return;
        _open = true;
        GetComponent<Animator>()?.SetTrigger(Open);
    }

    private void SpawnDrop()
    {
        var gameObject = Instantiate(drop, transform.position + Vector3.down, Quaternion.identity);
        gameObject.transform.SetParent(transform);
        var dropObject = gameObject.GetComponent<DropItemController>();
        if (dropObject)
            dropObject.quantity = quantity;
        if (openSound)
            GetComponent<AudioSource>()?.PlayOneShot(openSound);
    }
}