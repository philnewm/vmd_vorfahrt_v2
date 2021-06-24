// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Controls.inputactions'

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
            ""name"": ""SceneController"",
            ""id"": ""3a1fa04f-c466-4e23-89ae-cb67abb0a656"",
            ""actions"": [
                {
                    ""name"": ""RotationControl"",
                    ""type"": ""PassThrough"",
                    ""id"": ""beb0d4f5-1755-4d99-8e9b-6cb1e3c93ec8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""51739d57-748d-436b-b37d-1263632ab547"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""vertical_rotation"",
                    ""type"": ""Value"",
                    ""id"": ""401c91f0-fcd2-44ab-b4cf-ca766076c7de"",
                    ""expectedControlType"": ""Button"",
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
                    ""id"": ""8cb394aa-6d17-4842-994c-ac967b829cde"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6e98672-6da4-418d-b109-3a58c1b9c9b1"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""0dd100f8-9a63-416c-9aa8-e50f55d2117f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""vertical_rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""98833577-2ce5-4cca-8d2b-f72d8fefdc21"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""vertical_rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d00bc235-e83e-44af-ae28-4f615c2b6ad6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""vertical_rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""d1901e9d-615b-4b26-a5f6-f66e864feeb2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""vertical_rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""95f72c9c-4da6-4389-93a2-b584aa657b83"",
                    ""path"": ""<Touchscreen>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""vertical_rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6b942ef4-286b-4f8a-87f0-3e4ae6379b1d"",
                    ""path"": ""<Touchscreen>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""vertical_rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // SceneController
        m_SceneController = asset.FindActionMap("SceneController", throwIfNotFound: true);
        m_SceneController_RotationControl = m_SceneController.FindAction("RotationControl", throwIfNotFound: true);
        m_SceneController_Click = m_SceneController.FindAction("Click", throwIfNotFound: true);
        m_SceneController_vertical_rotation = m_SceneController.FindAction("vertical_rotation", throwIfNotFound: true);
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

    // SceneController
    private readonly InputActionMap m_SceneController;
    private ISceneControllerActions m_SceneControllerActionsCallbackInterface;
    private readonly InputAction m_SceneController_RotationControl;
    private readonly InputAction m_SceneController_Click;
    private readonly InputAction m_SceneController_vertical_rotation;
    public struct SceneControllerActions
    {
        private @Controls m_Wrapper;
        public SceneControllerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RotationControl => m_Wrapper.m_SceneController_RotationControl;
        public InputAction @Click => m_Wrapper.m_SceneController_Click;
        public InputAction @vertical_rotation => m_Wrapper.m_SceneController_vertical_rotation;
        public InputActionMap Get() { return m_Wrapper.m_SceneController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SceneControllerActions set) { return set.Get(); }
        public void SetCallbacks(ISceneControllerActions instance)
        {
            if (m_Wrapper.m_SceneControllerActionsCallbackInterface != null)
            {
                @RotationControl.started -= m_Wrapper.m_SceneControllerActionsCallbackInterface.OnRotationControl;
                @RotationControl.performed -= m_Wrapper.m_SceneControllerActionsCallbackInterface.OnRotationControl;
                @RotationControl.canceled -= m_Wrapper.m_SceneControllerActionsCallbackInterface.OnRotationControl;
                @Click.started -= m_Wrapper.m_SceneControllerActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_SceneControllerActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_SceneControllerActionsCallbackInterface.OnClick;
                @vertical_rotation.started -= m_Wrapper.m_SceneControllerActionsCallbackInterface.OnVertical_rotation;
                @vertical_rotation.performed -= m_Wrapper.m_SceneControllerActionsCallbackInterface.OnVertical_rotation;
                @vertical_rotation.canceled -= m_Wrapper.m_SceneControllerActionsCallbackInterface.OnVertical_rotation;
            }
            m_Wrapper.m_SceneControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RotationControl.started += instance.OnRotationControl;
                @RotationControl.performed += instance.OnRotationControl;
                @RotationControl.canceled += instance.OnRotationControl;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @vertical_rotation.started += instance.OnVertical_rotation;
                @vertical_rotation.performed += instance.OnVertical_rotation;
                @vertical_rotation.canceled += instance.OnVertical_rotation;
            }
        }
    }
    public SceneControllerActions @SceneController => new SceneControllerActions(this);
    public interface ISceneControllerActions
    {
        void OnRotationControl(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnVertical_rotation(InputAction.CallbackContext context);
    }
}
