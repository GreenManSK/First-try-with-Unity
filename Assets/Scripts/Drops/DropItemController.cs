using Constants;
using TMPro;
using UnityEngine;

public class DropItemController : MonoBehaviour
{
    public DropType type = DropType.Unknown;
    public int quantity = 1;

    public AudioClip pickUpSound;
    public GameObject textEffect;
    public GameObject destroyEffect;

    private AudioSource _audioSource;
    private bool _collected;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Collect()
    {
        if (_collected) return;
        _collected = true;
        DisplayText();
        var delay = 0f;
        if (_audioSource != null && pickUpSound != null)
        {
            delay = pickUpSound.length;
            _audioSource.PlayOneShot(pickUpSound);
            foreach (var sprite in GetComponentsInChildren<SpriteRenderer>())
            {
                sprite.gameObject.SetActive(false);
            }
        }

        Destroy(gameObject, delay);
    }

    public bool isCollected()
    {
        return _collected;
    }

    private void DisplayText()
    {
        var canvas = GameObject.FindWithTag(Tags.TextEffectCanvas);
        if (canvas == null) return;
        var position = transform.position;
        SpawnText(canvas.gameObject, position + Vector3.up);
        SpawnText(canvas.gameObject, position + Vector3.up - new Vector3(Game.PIXEL, -Game.PIXEL, 0)).color =
            Colors.White;
    }

    private TextMeshProUGUI SpawnText(GameObject canvas, Vector3 position)
    {
        var gameObject = Instantiate(textEffect, transform.position, Quaternion.identity);
        gameObject.transform.SetParent(canvas.transform, false);
        gameObject.GetComponent<RectTransform>().anchoredPosition3D = position;
        var text = gameObject.GetComponent<TextMeshProUGUI>();
        text.text = quantity.ToString();
        return text;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(Tags.DropDeleter)) return;
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}