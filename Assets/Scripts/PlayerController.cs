using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

enum MoveType
{
    Stab,
    Swing
}

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private const float ToolDistance = .7f;

    public float moveSpeed = 5f;
    public GameObject activeTool;
    public List<GameObject> tools;

    private PlayerControlls _controlls;
    private Rigidbody2D _rigidbody2D;

    private Vector2 _movement = Vector2.zero;

    private bool _usingTool = false;
    private int _activeToolIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (tools.Count > 0)
        {
            activeTool = tools.First();
        }
    }

    private void OnEnable()
    {
        _controlls.Gameplay.Enable();
    }

    private void Awake()
    {
        _controlls = new PlayerControlls();

        _controlls.Gameplay.Move.performed += ctx => _movement = ctx.ReadValue<Vector2>();
        _controlls.Gameplay.Move.canceled += ctx => _movement = Vector2.zero;

        _controlls.Gameplay.Stab.performed += ctx => UseTool(MoveType.Stab);
        _controlls.Gameplay.Swing.performed += ctx => UseTool(MoveType.Swing);

        _controlls.Gameplay.ToolChange.performed += ctx => ChangeTool(ctx.ReadValue<float>() > 0);
        _controlls.Gameplay.ToolNext.performed += ctx => ChangeTool(true);
        _controlls.Gameplay.ToolPrev.performed += ctx => ChangeTool(false);
    }

    private void ChangeTool(bool next)
    {
        if (tools.Count == 0)
            return;
        _activeToolIndex = (_activeToolIndex + (next ? 1 : -1) + tools.Count) % tools.Count;
        activeTool = tools[_activeToolIndex];
    }

    private void FixedUpdate()
    {
        if (_usingTool)
            return;
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movement * moveSpeed * Time.fixedDeltaTime);

        if (_movement != Vector2.zero)
        {
            var angle = Mathf.Round((Mathf.Atan2(_movement.y, _movement.x) * Mathf.Rad2Deg + 90f) / 90f) * 90f;
            _rigidbody2D.rotation = angle;
        }
    }

    private void UseTool(MoveType type)
    {
        if (_usingTool || activeTool == null)
            return;
        Vector2 rotationVector = Quaternion.Euler(0, 0, _rigidbody2D.rotation) * Vector2.down;
        var toolGameObject = Instantiate(
            activeTool,
            _rigidbody2D.position + rotationVector * ToolDistance,
            Quaternion.Euler(0, 0, _rigidbody2D.rotation + 180f)
        );

        var tool = toolGameObject.GetComponent<ToolController>();
        if (!tool) return;

        _usingTool = true;
        tool.destroyed += () => _usingTool = false;
        switch (type)
        {
            case MoveType.Swing:
                tool.Swing();
                break;
            case MoveType.Stab:
                tool.Stab();
                break;
        }
    }
}