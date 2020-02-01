// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControlls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @PlayerControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""064a8f22-f27e-45b8-bd01-de18ea0032e6"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""5a39430c-dc40-44f6-aa0c-04f0c5f86afa"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Stab"",
                    ""type"": ""Button"",
                    ""id"": ""d4e19460-e4e1-46dc-a46f-11dcd2717a8f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swing"",
                    ""type"": ""Button"",
                    ""id"": ""2394f2b4-4296-41a8-b19a-35f11483832f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToolChange"",
                    ""type"": ""Button"",
                    ""id"": ""c0b9c0f4-5e66-4d98-9675-caabd21f7590"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToolPrev"",
                    ""type"": ""Button"",
                    ""id"": ""0d467c61-4e2d-4b62-a3e9-73398388eda3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToolNext"",
                    ""type"": ""Button"",
                    ""id"": ""39b73978-9025-4bfd-ad06-a5eff067f196"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToolChangeNumbers"",
                    ""type"": ""Button"",
                    ""id"": ""657fc9c9-7ce9-4008-9b9c-34291e2e2a4f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""55b3edbb-7c7b-4b45-8c3d-d5f96c369b49"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e0ca3cfd-abd7-4a4b-95a0-45d8a26a3ac5"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""e0005039-85e2-45d9-8874-e58481614f66"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a539e567-feea-42e8-88be-f4c9d6db803d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6bf0a134-a046-47af-bb5e-a34e82c93255"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c539fd33-656b-4905-b491-a4960cdf6fdd"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1056c3d8-172f-4e65-87c0-2cacc88d3fbb"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WSAD"",
                    ""id"": ""5dd14860-52fb-485a-bf7e-2701287e63f4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""94166fb7-e91a-4772-aac6-c12382c67618"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0e7db2df-4af0-4e50-8665-93cf3d338bc4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9805ffe4-a729-45af-8feb-91bec5b20bfe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7a4785b8-017e-4f91-baaa-ab56d2189816"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a360d89a-1784-450c-953d-554be75dffc3"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46b5ae6d-570e-409b-953a-1d60b1883622"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c14639af-e5de-4e38-9058-e1e95c00f31f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0511874-6d70-4d64-ad76-baaeec0c587f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32012523-a1d6-4445-a576-b6b8588b1459"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""877d57bf-312d-459d-a741-9774b048bbdf"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59f5ef08-ec96-489e-95a0-531d4c924b79"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91d1b899-3cf4-49c2-a244-3ce614d125e1"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd65039a-8e61-451b-a97d-48af79d098e4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4794d03-64f0-4eec-8991-d144c02f9c2a"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToolChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18ed842a-d175-4450-8ae3-b5ca10468829"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToolPrev"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3b5428b-1e7a-465c-994b-e8ff9e6c2277"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToolNext"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bef09e5-7223-4aed-a619-e896d86f591c"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToolChangeNumbers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""256cac48-acd2-4d64-a899-9e7764db3d9a"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToolChangeNumbers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7633271-fba0-4823-920c-45e517c63faf"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToolChangeNumbers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39c8860e-4a28-401f-a960-1b38479c0988"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToolChangeNumbers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0a43522-4741-4e29-932e-f3193b33080a"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToolChangeNumbers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b82ab129-ff9b-4b28-b040-b8836466ba64"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToolChangeNumbers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b273617f-0095-44a0-8ff1-b4a95c1b208f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3de46ab5-0d29-4120-96b0-e559ab38aef6"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7de6e08e-f80e-4ff7-bbf3-07fce68da279"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Stab = m_Gameplay.FindAction("Stab", throwIfNotFound: true);
        m_Gameplay_Swing = m_Gameplay.FindAction("Swing", throwIfNotFound: true);
        m_Gameplay_ToolChange = m_Gameplay.FindAction("ToolChange", throwIfNotFound: true);
        m_Gameplay_ToolPrev = m_Gameplay.FindAction("ToolPrev", throwIfNotFound: true);
        m_Gameplay_ToolNext = m_Gameplay.FindAction("ToolNext", throwIfNotFound: true);
        m_Gameplay_ToolChangeNumbers = m_Gameplay.FindAction("ToolChangeNumbers", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Stab;
    private readonly InputAction m_Gameplay_Swing;
    private readonly InputAction m_Gameplay_ToolChange;
    private readonly InputAction m_Gameplay_ToolPrev;
    private readonly InputAction m_Gameplay_ToolNext;
    private readonly InputAction m_Gameplay_ToolChangeNumbers;
    private readonly InputAction m_Gameplay_Pause;
    public struct GameplayActions
    {
        private @PlayerControlls m_Wrapper;
        public GameplayActions(@PlayerControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Stab => m_Wrapper.m_Gameplay_Stab;
        public InputAction @Swing => m_Wrapper.m_Gameplay_Swing;
        public InputAction @ToolChange => m_Wrapper.m_Gameplay_ToolChange;
        public InputAction @ToolPrev => m_Wrapper.m_Gameplay_ToolPrev;
        public InputAction @ToolNext => m_Wrapper.m_Gameplay_ToolNext;
        public InputAction @ToolChangeNumbers => m_Wrapper.m_Gameplay_ToolChangeNumbers;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Stab.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStab;
                @Stab.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStab;
                @Stab.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStab;
                @Swing.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwing;
                @Swing.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwing;
                @Swing.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwing;
                @ToolChange.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToolChange;
                @ToolChange.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToolChange;
                @ToolChange.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToolChange;
                @ToolPrev.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToolPrev;
                @ToolPrev.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToolPrev;
                @ToolPrev.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToolPrev;
                @ToolNext.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToolNext;
                @ToolNext.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToolNext;
                @ToolNext.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToolNext;
                @ToolChangeNumbers.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToolChangeNumbers;
                @ToolChangeNumbers.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToolChangeNumbers;
                @ToolChangeNumbers.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToolChangeNumbers;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Stab.started += instance.OnStab;
                @Stab.performed += instance.OnStab;
                @Stab.canceled += instance.OnStab;
                @Swing.started += instance.OnSwing;
                @Swing.performed += instance.OnSwing;
                @Swing.canceled += instance.OnSwing;
                @ToolChange.started += instance.OnToolChange;
                @ToolChange.performed += instance.OnToolChange;
                @ToolChange.canceled += instance.OnToolChange;
                @ToolPrev.started += instance.OnToolPrev;
                @ToolPrev.performed += instance.OnToolPrev;
                @ToolPrev.canceled += instance.OnToolPrev;
                @ToolNext.started += instance.OnToolNext;
                @ToolNext.performed += instance.OnToolNext;
                @ToolNext.canceled += instance.OnToolNext;
                @ToolChangeNumbers.started += instance.OnToolChangeNumbers;
                @ToolChangeNumbers.performed += instance.OnToolChangeNumbers;
                @ToolChangeNumbers.canceled += instance.OnToolChangeNumbers;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnStab(InputAction.CallbackContext context);
        void OnSwing(InputAction.CallbackContext context);
        void OnToolChange(InputAction.CallbackContext context);
        void OnToolPrev(InputAction.CallbackContext context);
        void OnToolNext(InputAction.CallbackContext context);
        void OnToolChangeNumbers(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
