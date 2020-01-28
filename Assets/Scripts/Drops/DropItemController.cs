using System.Diagnostics;
using Constants;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class DropItemController : MonoBehaviour
{
    public DropType type = DropType.Unknown;
    public int quantity = 1;

    public AudioClip pickUpSound;
    public GameObject textEffect;

    private AudioSource _audioSource;
    private BoxCollider2D _collider;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _collider = GetComponent<BoxCollider2D>();
    }

    public void Collect()
    {
        Destroy(_collider);
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

    private void DisplayText()
    {
        var canvas = GameObject.FindWithTag(Tags.TextEffectCanvas);
        if (canvas != null)
        {
            var gameObject = Instantiate(textEffect, transform.position, Quaternion.identity);
            gameObject.transform.SetParent(canvas.transform, false);
            gameObject.GetComponent<RectTransform>().anchoredPosition3D = transform.position + Vector3.up;
            gameObject.GetComponent<Text>().text = quantity.ToString();
        }
    }
}