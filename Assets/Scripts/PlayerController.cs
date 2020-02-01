using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Tools;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

internal enum MoveType
{
    Stab,
    Swing
}

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private const float ToolDistance = .6f;
    private static readonly int AnimatorMoveX = Animator.StringToHash("Move X");
    private static readonly int AnimatorMoveY = Animator.StringToHash("Move Y");

    public delegate void ToolChangeDelegate(int activeIndex);

    public float moveSpeed = 5f;
    public GameObject activeTool;
    public List<GameObject> tools;

    public event ToolChangeDelegate ToolChanged;

    private PlayerControlls _controlls;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private Vector2 _movement = Vector2.zero;
    private float _rotation;

    private bool _usingTool;
    private int _activeToolIndex;

    private ToolController _toolInstance;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        if (tools.Count > 0)
        {
            activeTool = tools.First();
        }
    }

    public int GetActiveToolIndex()
    {
        return _activeToolIndex;
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

        _controlls.Gameplay.Stab.started += ctx => UseTool(MoveType.Stab);
        _controlls.Gameplay.Swing.started += ctx => UseTool(MoveType.Swing);
        _controlls.Gameplay.Stab.canceled += ctx => StopUsingTool();
        _controlls.Gameplay.Swing.canceled += ctx => StopUsingTool();

        _controlls.Gameplay.ToolChange.performed += ctx => ChangeTool(ctx.ReadValue<float>() < 0);
        _controlls.Gameplay.ToolChangeNumbers.performed += ctx =>
        {
            if (ctx.control is KeyControl control)
            {
                ChangeTool(InputHelper.KeyToNumber(control.keyCode) - 1);
            }
        };
        _controlls.Gameplay.ToolNext.performed += ctx => ChangeTool(true);
        _controlls.Gameplay.ToolPrev.performed += ctx => ChangeTool(false);

        _controlls.Gameplay.Pause.performed += ctx => PauseController.Toggle();
    }

    private void ChangeTool(bool next)
    {
        ChangeTool(tools.Count + _activeToolIndex + (next ? 1 : -1));
    }

    private void ChangeTool(int index)
    {
        if (tools.Count == 0)
            return;
        _activeToolIndex = index % tools.Count;
        activeTool = tools[_activeToolIndex];
        ToolChanged?.Invoke(_activeToolIndex);
    }

    private void Update()
    {
        if (_usingTool || _movement == Vector2.zero)
            return;

        if (_movement.magnitude < 0.01f)
            return;
        _animator.SetFloat(AnimatorMoveX, _movement.x);
        _animator.SetFloat(AnimatorMoveY, _movement.y);
        if (_movement != Vector2.zero)
        {
            _rotation = Mathf.Round((Mathf.Atan2(_movement.y, _movement.x) * Mathf.Rad2Deg + 90f) / 90f) * 90f;
        }
    }

    private void FixedUpdate()
    {
        if (_usingTool)
            return;
        _rigidbody2D.MovePosition(_rigidbody2D.position + moveSpeed * Time.fixedDeltaTime * _movement);
    }

    private void UseTool(MoveType type)
    {
        if (_usingTool || activeTool == null)
            return;
        Vector2 rotationVector = Quaternion.Euler(0, 0, _rotation) * Vector2.down;
        var toolGameObject = Instantiate(
            activeTool,
            _rigidbody2D.position + rotationVector * ToolDistance,
            Quaternion.Euler(0, 0, _rotation + 180f)
        );

        _toolInstance = toolGameObject.GetComponent<ToolController>();
        if (!_toolInstance) return;

        _usingTool = true;
        _toolInstance.Destroyed += () => _usingTool = false;
        switch (type)
        {
            case MoveType.Swing:
                _toolInstance.Swing();
                break;
            case MoveType.Stab:
                _toolInstance.Stab();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    private void StopUsingTool()
    {
        if (_toolInstance)
        {
            _toolInstance.Delete();
        }
    }
}