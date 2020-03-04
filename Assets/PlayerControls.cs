// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""ff574345-7c56-4903-9cd1-fb179373f515"",
            ""actions"": [
                {
                    ""name"": ""Order_0"",
                    ""type"": ""Button"",
                    ""id"": ""f195bf6f-ef7d-40be-9725-9d7f101ee976"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Order_1"",
                    ""type"": ""Button"",
                    ""id"": ""17dc7633-0961-4444-8bef-e23524aa5a2b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Order_2"",
                    ""type"": ""Button"",
                    ""id"": ""55f8e27d-c0ea-4c85-b2e9-c25dea659481"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Order_3"",
                    ""type"": ""Button"",
                    ""id"": ""04a639c6-d142-416e-8e3a-094917b9eb47"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b6751008-620e-40cf-b7eb-3658459d9c48"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Order_0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19a62590-43c2-4e00-b4e2-0f73cd7cea7f"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Order_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64e9d890-c4cb-4f0e-aa21-14b1d4e21581"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Order_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3279a197-f6d8-4045-bed7-081b4c1fc796"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Order_3"",
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
        m_Gameplay_Order_0 = m_Gameplay.FindAction("Order_0", throwIfNotFound: true);
        m_Gameplay_Order_1 = m_Gameplay.FindAction("Order_1", throwIfNotFound: true);
        m_Gameplay_Order_2 = m_Gameplay.FindAction("Order_2", throwIfNotFound: true);
        m_Gameplay_Order_3 = m_Gameplay.FindAction("Order_3", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Order_0;
    private readonly InputAction m_Gameplay_Order_1;
    private readonly InputAction m_Gameplay_Order_2;
    private readonly InputAction m_Gameplay_Order_3;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Order_0 => m_Wrapper.m_Gameplay_Order_0;
        public InputAction @Order_1 => m_Wrapper.m_Gameplay_Order_1;
        public InputAction @Order_2 => m_Wrapper.m_Gameplay_Order_2;
        public InputAction @Order_3 => m_Wrapper.m_Gameplay_Order_3;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Order_0.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOrder_0;
                @Order_0.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOrder_0;
                @Order_0.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOrder_0;
                @Order_1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOrder_1;
                @Order_1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOrder_1;
                @Order_1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOrder_1;
                @Order_2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOrder_2;
                @Order_2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOrder_2;
                @Order_2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOrder_2;
                @Order_3.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOrder_3;
                @Order_3.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOrder_3;
                @Order_3.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOrder_3;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Order_0.started += instance.OnOrder_0;
                @Order_0.performed += instance.OnOrder_0;
                @Order_0.canceled += instance.OnOrder_0;
                @Order_1.started += instance.OnOrder_1;
                @Order_1.performed += instance.OnOrder_1;
                @Order_1.canceled += instance.OnOrder_1;
                @Order_2.started += instance.OnOrder_2;
                @Order_2.performed += instance.OnOrder_2;
                @Order_2.canceled += instance.OnOrder_2;
                @Order_3.started += instance.OnOrder_3;
                @Order_3.performed += instance.OnOrder_3;
                @Order_3.canceled += instance.OnOrder_3;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnOrder_0(InputAction.CallbackContext context);
        void OnOrder_1(InputAction.CallbackContext context);
        void OnOrder_2(InputAction.CallbackContext context);
        void OnOrder_3(InputAction.CallbackContext context);
    }
}
