// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""ObjectController"",
            ""id"": ""3a1fa04f-c466-4e23-89ae-cb67abb0a656"",
            ""actions"": [
                {
                    ""name"": ""RotationControl"",
                    ""type"": ""Value"",
                    ""id"": ""beb0d4f5-1755-4d99-8e9b-6cb1e3c93ec8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""KeyboardInput"",
                    ""id"": ""022d2f62-fa18-4837-aeae-e85b376d9b24"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5be3ca52-e94f-4287-82ad-1f5432f4389b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""74f938ac-efdf-4803-9f31-eeb478f1cc50"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ac019d6d-01ad-4033-9180-66a7754276ba"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d85b52e6-d6a6-4aeb-b95c-375e9349f79b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""726e61d3-b002-49fd-a1dd-089f5c553bc0"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5910472d-225d-4cf0-a20f-0ecdee77c893"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5161434-822f-403c-acdd-33f1ab951755"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ObjectController
        m_ObjectController = asset.FindActionMap("ObjectController", throwIfNotFound: true);
        m_ObjectController_RotationControl = m_ObjectController.FindAction("RotationControl", throwIfNotFound: true);
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

    // ObjectController
    private readonly InputActionMap m_ObjectController;
    private IObjectControllerActions m_ObjectControllerActionsCallbackInterface;
    private readonly InputAction m_ObjectController_RotationControl;
    public struct ObjectControllerActions
    {
        private @Controls m_Wrapper;
        public ObjectControllerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RotationControl => m_Wrapper.m_ObjectController_RotationControl;
        public InputActionMap Get() { return m_Wrapper.m_ObjectController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ObjectControllerActions set) { return set.Get(); }
        public void SetCallbacks(IObjectControllerActions instance)
        {
            if (m_Wrapper.m_ObjectControllerActionsCallbackInterface != null)
            {
                @RotationControl.started -= m_Wrapper.m_ObjectControllerActionsCallbackInterface.OnRotationControl;
                @RotationControl.performed -= m_Wrapper.m_ObjectControllerActionsCallbackInterface.OnRotationControl;
                @RotationControl.canceled -= m_Wrapper.m_ObjectControllerActionsCallbackInterface.OnRotationControl;
            }
            m_Wrapper.m_ObjectControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RotationControl.started += instance.OnRotationControl;
                @RotationControl.performed += instance.OnRotationControl;
                @RotationControl.canceled += instance.OnRotationControl;
            }
        }
    }
    public ObjectControllerActions @ObjectController => new ObjectControllerActions(this);
    public interface IObjectControllerActions
    {
        void OnRotationControl(InputAction.CallbackContext context);
    }
}
