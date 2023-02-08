//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputActions/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""BasicControls"",
            ""id"": ""d85ee3e7-7c18-4704-b540-a6af510e3066"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d7b5f531-5d2b-4187-9fcb-65ab8c7d5199"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""71632a37-63ba-4b22-8940-8004fa7aab3f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""85a0d725-a2b2-494a-9079-7a10b8132962"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35879a27-1181-41eb-9f75-4e6c154874ad"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BasicControls
        m_BasicControls = asset.FindActionMap("BasicControls", throwIfNotFound: true);
        m_BasicControls_Jump = m_BasicControls.FindAction("Jump", throwIfNotFound: true);
        m_BasicControls_Move = m_BasicControls.FindAction("Move", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // BasicControls
    private readonly InputActionMap m_BasicControls;
    private IBasicControlsActions m_BasicControlsActionsCallbackInterface;
    private readonly InputAction m_BasicControls_Jump;
    private readonly InputAction m_BasicControls_Move;
    public struct BasicControlsActions
    {
        private @PlayerControls m_Wrapper;
        public BasicControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_BasicControls_Jump;
        public InputAction @Move => m_Wrapper.m_BasicControls_Move;
        public InputActionMap Get() { return m_Wrapper.m_BasicControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicControlsActions set) { return set.Get(); }
        public void SetCallbacks(IBasicControlsActions instance)
        {
            if (m_Wrapper.m_BasicControlsActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_BasicControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BasicControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BasicControlsActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_BasicControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_BasicControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_BasicControlsActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_BasicControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public BasicControlsActions @BasicControls => new BasicControlsActions(this);
    public interface IBasicControlsActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
