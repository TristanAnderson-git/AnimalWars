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
            ""name"": ""Orders"",
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
        },
        {
            ""name"": ""Construction"",
            ""id"": ""e5a11009-fdaa-49d3-9386-efbd8198f99f"",
            ""actions"": [
                {
                    ""name"": ""RightStick"",
                    ""type"": ""Value"",
                    ""id"": ""318200be-ccad-40e6-8d1b-68db4ee2c4cf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CancelBuild"",
                    ""type"": ""Button"",
                    ""id"": ""e99245d6-67ea-4f7a-b7e2-91493a72c335"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Build"",
                    ""type"": ""Button"",
                    ""id"": ""34a99d64-3010-4ca6-b638-4f3212c0d82d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapNext"",
                    ""type"": ""Button"",
                    ""id"": ""c1cbca07-2ecf-42e6-9eb8-b4521e568327"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapPrevious"",
                    ""type"": ""Button"",
                    ""id"": ""ae0cde4c-0bc0-4fdc-9b78-707cb3120aa6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ebe48b07-389e-4015-b280-67c37747af7d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33ec323f-d71b-4750-bd11-4c04325e57e6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelBuild"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5730cbb9-b384-4781-9f35-4a3206e67769"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""590b27d2-61b6-497a-96c3-bfc90dafa6b6"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapNext"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37f8408c-65d0-41b8-b9d6-081aa4080cbe"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapPrevious"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Orders
        m_Orders = asset.FindActionMap("Orders", throwIfNotFound: true);
        m_Orders_Order_0 = m_Orders.FindAction("Order_0", throwIfNotFound: true);
        m_Orders_Order_1 = m_Orders.FindAction("Order_1", throwIfNotFound: true);
        m_Orders_Order_2 = m_Orders.FindAction("Order_2", throwIfNotFound: true);
        m_Orders_Order_3 = m_Orders.FindAction("Order_3", throwIfNotFound: true);
        // Construction
        m_Construction = asset.FindActionMap("Construction", throwIfNotFound: true);
        m_Construction_RightStick = m_Construction.FindAction("RightStick", throwIfNotFound: true);
        m_Construction_CancelBuild = m_Construction.FindAction("CancelBuild", throwIfNotFound: true);
        m_Construction_Build = m_Construction.FindAction("Build", throwIfNotFound: true);
        m_Construction_SwapNext = m_Construction.FindAction("SwapNext", throwIfNotFound: true);
        m_Construction_SwapPrevious = m_Construction.FindAction("SwapPrevious", throwIfNotFound: true);
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

    // Orders
    private readonly InputActionMap m_Orders;
    private IOrdersActions m_OrdersActionsCallbackInterface;
    private readonly InputAction m_Orders_Order_0;
    private readonly InputAction m_Orders_Order_1;
    private readonly InputAction m_Orders_Order_2;
    private readonly InputAction m_Orders_Order_3;
    public struct OrdersActions
    {
        private @PlayerControls m_Wrapper;
        public OrdersActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Order_0 => m_Wrapper.m_Orders_Order_0;
        public InputAction @Order_1 => m_Wrapper.m_Orders_Order_1;
        public InputAction @Order_2 => m_Wrapper.m_Orders_Order_2;
        public InputAction @Order_3 => m_Wrapper.m_Orders_Order_3;
        public InputActionMap Get() { return m_Wrapper.m_Orders; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OrdersActions set) { return set.Get(); }
        public void SetCallbacks(IOrdersActions instance)
        {
            if (m_Wrapper.m_OrdersActionsCallbackInterface != null)
            {
                @Order_0.started -= m_Wrapper.m_OrdersActionsCallbackInterface.OnOrder_0;
                @Order_0.performed -= m_Wrapper.m_OrdersActionsCallbackInterface.OnOrder_0;
                @Order_0.canceled -= m_Wrapper.m_OrdersActionsCallbackInterface.OnOrder_0;
                @Order_1.started -= m_Wrapper.m_OrdersActionsCallbackInterface.OnOrder_1;
                @Order_1.performed -= m_Wrapper.m_OrdersActionsCallbackInterface.OnOrder_1;
                @Order_1.canceled -= m_Wrapper.m_OrdersActionsCallbackInterface.OnOrder_1;
                @Order_2.started -= m_Wrapper.m_OrdersActionsCallbackInterface.OnOrder_2;
                @Order_2.performed -= m_Wrapper.m_OrdersActionsCallbackInterface.OnOrder_2;
                @Order_2.canceled -= m_Wrapper.m_OrdersActionsCallbackInterface.OnOrder_2;
                @Order_3.started -= m_Wrapper.m_OrdersActionsCallbackInterface.OnOrder_3;
                @Order_3.performed -= m_Wrapper.m_OrdersActionsCallbackInterface.OnOrder_3;
                @Order_3.canceled -= m_Wrapper.m_OrdersActionsCallbackInterface.OnOrder_3;
            }
            m_Wrapper.m_OrdersActionsCallbackInterface = instance;
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
    public OrdersActions @Orders => new OrdersActions(this);

    // Construction
    private readonly InputActionMap m_Construction;
    private IConstructionActions m_ConstructionActionsCallbackInterface;
    private readonly InputAction m_Construction_RightStick;
    private readonly InputAction m_Construction_CancelBuild;
    private readonly InputAction m_Construction_Build;
    private readonly InputAction m_Construction_SwapNext;
    private readonly InputAction m_Construction_SwapPrevious;
    public struct ConstructionActions
    {
        private @PlayerControls m_Wrapper;
        public ConstructionActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightStick => m_Wrapper.m_Construction_RightStick;
        public InputAction @CancelBuild => m_Wrapper.m_Construction_CancelBuild;
        public InputAction @Build => m_Wrapper.m_Construction_Build;
        public InputAction @SwapNext => m_Wrapper.m_Construction_SwapNext;
        public InputAction @SwapPrevious => m_Wrapper.m_Construction_SwapPrevious;
        public InputActionMap Get() { return m_Wrapper.m_Construction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ConstructionActions set) { return set.Get(); }
        public void SetCallbacks(IConstructionActions instance)
        {
            if (m_Wrapper.m_ConstructionActionsCallbackInterface != null)
            {
                @RightStick.started -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnRightStick;
                @RightStick.performed -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnRightStick;
                @RightStick.canceled -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnRightStick;
                @CancelBuild.started -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnCancelBuild;
                @CancelBuild.performed -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnCancelBuild;
                @CancelBuild.canceled -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnCancelBuild;
                @Build.started -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnBuild;
                @Build.performed -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnBuild;
                @Build.canceled -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnBuild;
                @SwapNext.started -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnSwapNext;
                @SwapNext.performed -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnSwapNext;
                @SwapNext.canceled -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnSwapNext;
                @SwapPrevious.started -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnSwapPrevious;
                @SwapPrevious.performed -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnSwapPrevious;
                @SwapPrevious.canceled -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnSwapPrevious;
            }
            m_Wrapper.m_ConstructionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RightStick.started += instance.OnRightStick;
                @RightStick.performed += instance.OnRightStick;
                @RightStick.canceled += instance.OnRightStick;
                @CancelBuild.started += instance.OnCancelBuild;
                @CancelBuild.performed += instance.OnCancelBuild;
                @CancelBuild.canceled += instance.OnCancelBuild;
                @Build.started += instance.OnBuild;
                @Build.performed += instance.OnBuild;
                @Build.canceled += instance.OnBuild;
                @SwapNext.started += instance.OnSwapNext;
                @SwapNext.performed += instance.OnSwapNext;
                @SwapNext.canceled += instance.OnSwapNext;
                @SwapPrevious.started += instance.OnSwapPrevious;
                @SwapPrevious.performed += instance.OnSwapPrevious;
                @SwapPrevious.canceled += instance.OnSwapPrevious;
            }
        }
    }
    public ConstructionActions @Construction => new ConstructionActions(this);
    public interface IOrdersActions
    {
        void OnOrder_0(InputAction.CallbackContext context);
        void OnOrder_1(InputAction.CallbackContext context);
        void OnOrder_2(InputAction.CallbackContext context);
        void OnOrder_3(InputAction.CallbackContext context);
    }
    public interface IConstructionActions
    {
        void OnRightStick(InputAction.CallbackContext context);
        void OnCancelBuild(InputAction.CallbackContext context);
        void OnBuild(InputAction.CallbackContext context);
        void OnSwapNext(InputAction.CallbackContext context);
        void OnSwapPrevious(InputAction.CallbackContext context);
    }
}
