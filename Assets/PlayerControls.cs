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
                    ""name"": ""Uknown"",
                    ""type"": ""Value"",
                    ""id"": ""f195bf6f-ef7d-40be-9725-9d7f101ee976"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Value"",
                    ""id"": ""17dc7633-0961-4444-8bef-e23524aa5a2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gather"",
                    ""type"": ""Value"",
                    ""id"": ""55f8e27d-c0ea-4c85-b2e9-c25dea659481"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Follow"",
                    ""type"": ""Value"",
                    ""id"": ""04a639c6-d142-416e-8e3a-094917b9eb47"",
                    ""expectedControlType"": ""Button"",
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
                    ""action"": ""Uknown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a77b6909-5d24-48f5-9feb-c97cb4a024b9"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Uknown"",
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
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b614cc14-49f9-4f9a-88c1-a0d69d7e7cca"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
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
                    ""action"": ""Gather"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c087472-f650-4744-ab4b-1ac983c93b4b"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gather"",
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
                    ""action"": ""Follow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a38dc78-5e80-4e2f-a892-4f18d4a51110"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Follow"",
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
                    ""name"": ""Place"",
                    ""type"": ""Value"",
                    ""id"": ""a3f44d51-f6dc-467a-b294-4bb2ac7af096"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Build"",
                    ""type"": ""Button"",
                    ""id"": ""e99245d6-67ea-4f7a-b7e2-91493a72c335"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Preview"",
                    ""type"": ""Value"",
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
                    ""action"": ""Preview"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f581c54-7dce-4451-98f0-417e346e1830"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Preview"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33ec323f-d71b-4750-bd11-4c04325e57e6"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc956e49-7f28-4f3f-a514-40d5e35d4c66"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build"",
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
                    ""id"": ""40c547f2-be9d-4c2a-baf5-443732f29bb1"",
                    ""path"": ""<Keyboard>/e"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""39f1bbfc-bff8-431c-8d33-ff9ba3f583a6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapPrevious"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a2ed736-f2d7-432d-bd8f-72cc35a3a914"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""[Keyboard]"",
                    ""id"": ""9ee46e98-4d65-49fd-ade4-3666541bbd73"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Place"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""74411a91-2f7a-47db-a372-f51a828a84f2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""69b58968-3552-409e-95aa-e39258b8cd8d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6640b1fa-36a1-4c07-978f-94d51aba6937"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""48ff95d4-447f-4415-b208-63c8ae6d11ce"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Movement"",
            ""id"": ""fac4a6db-7c7e-4f4c-83be-2fde83173f8c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a581877a-340b-4d31-afe1-9fbe1291c964"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8684cb8e-543f-4485-bd15-b8f51b326a24"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""[Keyboard]"",
                    ""id"": ""98cc3092-bc93-4e62-8840-934eb1134d58"",
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
                    ""id"": ""ec1d5690-1b04-47af-9f52-324e5adc4a11"",
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
                    ""id"": ""5328c99b-f203-40dd-993a-980675249445"",
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
                    ""id"": ""33adaaa4-bc2f-4f49-88ca-d6a0a87c1700"",
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
                    ""id"": ""406ce540-c808-4905-be1d-51ee731f9424"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Join"",
            ""id"": ""211bab3f-c465-4857-aa4b-331a239ecfbd"",
            ""actions"": [
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""e9fe3cd6-a4ea-467d-a798-02791994eccd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""ff06c6b6-757c-4eb8-b67d-a8e128ea9fe6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a83196ca-a4a5-4642-9e66-11e7a23542ce"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4b31038-5710-47b2-ace3-baf4092bdb8e"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24e4026a-bcce-4872-9a7f-20c799626e61"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""825ebdae-d105-4f7c-a210-160fd8b6de37"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
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
        m_Orders_Uknown = m_Orders.FindAction("Uknown", throwIfNotFound: true);
        m_Orders_Attack = m_Orders.FindAction("Attack", throwIfNotFound: true);
        m_Orders_Gather = m_Orders.FindAction("Gather", throwIfNotFound: true);
        m_Orders_Follow = m_Orders.FindAction("Follow", throwIfNotFound: true);
        // Construction
        m_Construction = asset.FindActionMap("Construction", throwIfNotFound: true);
        m_Construction_Place = m_Construction.FindAction("Place", throwIfNotFound: true);
        m_Construction_Build = m_Construction.FindAction("Build", throwIfNotFound: true);
        m_Construction_Preview = m_Construction.FindAction("Preview", throwIfNotFound: true);
        m_Construction_SwapNext = m_Construction.FindAction("SwapNext", throwIfNotFound: true);
        m_Construction_SwapPrevious = m_Construction.FindAction("SwapPrevious", throwIfNotFound: true);
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        // Join
        m_Join = asset.FindActionMap("Join", throwIfNotFound: true);
        m_Join_Confirm = m_Join.FindAction("Confirm", throwIfNotFound: true);
        m_Join_Cancel = m_Join.FindAction("Cancel", throwIfNotFound: true);
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
    private readonly InputAction m_Orders_Uknown;
    private readonly InputAction m_Orders_Attack;
    private readonly InputAction m_Orders_Gather;
    private readonly InputAction m_Orders_Follow;
    public struct OrdersActions
    {
        private @PlayerControls m_Wrapper;
        public OrdersActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Uknown => m_Wrapper.m_Orders_Uknown;
        public InputAction @Attack => m_Wrapper.m_Orders_Attack;
        public InputAction @Gather => m_Wrapper.m_Orders_Gather;
        public InputAction @Follow => m_Wrapper.m_Orders_Follow;
        public InputActionMap Get() { return m_Wrapper.m_Orders; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OrdersActions set) { return set.Get(); }
        public void SetCallbacks(IOrdersActions instance)
        {
            if (m_Wrapper.m_OrdersActionsCallbackInterface != null)
            {
                @Uknown.started -= m_Wrapper.m_OrdersActionsCallbackInterface.OnUknown;
                @Uknown.performed -= m_Wrapper.m_OrdersActionsCallbackInterface.OnUknown;
                @Uknown.canceled -= m_Wrapper.m_OrdersActionsCallbackInterface.OnUknown;
                @Attack.started -= m_Wrapper.m_OrdersActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_OrdersActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_OrdersActionsCallbackInterface.OnAttack;
                @Gather.started -= m_Wrapper.m_OrdersActionsCallbackInterface.OnGather;
                @Gather.performed -= m_Wrapper.m_OrdersActionsCallbackInterface.OnGather;
                @Gather.canceled -= m_Wrapper.m_OrdersActionsCallbackInterface.OnGather;
                @Follow.started -= m_Wrapper.m_OrdersActionsCallbackInterface.OnFollow;
                @Follow.performed -= m_Wrapper.m_OrdersActionsCallbackInterface.OnFollow;
                @Follow.canceled -= m_Wrapper.m_OrdersActionsCallbackInterface.OnFollow;
            }
            m_Wrapper.m_OrdersActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Uknown.started += instance.OnUknown;
                @Uknown.performed += instance.OnUknown;
                @Uknown.canceled += instance.OnUknown;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Gather.started += instance.OnGather;
                @Gather.performed += instance.OnGather;
                @Gather.canceled += instance.OnGather;
                @Follow.started += instance.OnFollow;
                @Follow.performed += instance.OnFollow;
                @Follow.canceled += instance.OnFollow;
            }
        }
    }
    public OrdersActions @Orders => new OrdersActions(this);

    // Construction
    private readonly InputActionMap m_Construction;
    private IConstructionActions m_ConstructionActionsCallbackInterface;
    private readonly InputAction m_Construction_Place;
    private readonly InputAction m_Construction_Build;
    private readonly InputAction m_Construction_Preview;
    private readonly InputAction m_Construction_SwapNext;
    private readonly InputAction m_Construction_SwapPrevious;
    public struct ConstructionActions
    {
        private @PlayerControls m_Wrapper;
        public ConstructionActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Place => m_Wrapper.m_Construction_Place;
        public InputAction @Build => m_Wrapper.m_Construction_Build;
        public InputAction @Preview => m_Wrapper.m_Construction_Preview;
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
                @Place.started -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnPlace;
                @Place.performed -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnPlace;
                @Place.canceled -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnPlace;
                @Build.started -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnBuild;
                @Build.performed -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnBuild;
                @Build.canceled -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnBuild;
                @Preview.started -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnPreview;
                @Preview.performed -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnPreview;
                @Preview.canceled -= m_Wrapper.m_ConstructionActionsCallbackInterface.OnPreview;
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
                @Place.started += instance.OnPlace;
                @Place.performed += instance.OnPlace;
                @Place.canceled += instance.OnPlace;
                @Build.started += instance.OnBuild;
                @Build.performed += instance.OnBuild;
                @Build.canceled += instance.OnBuild;
                @Preview.started += instance.OnPreview;
                @Preview.performed += instance.OnPreview;
                @Preview.canceled += instance.OnPreview;
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Move;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Join
    private readonly InputActionMap m_Join;
    private IJoinActions m_JoinActionsCallbackInterface;
    private readonly InputAction m_Join_Confirm;
    private readonly InputAction m_Join_Cancel;
    public struct JoinActions
    {
        private @PlayerControls m_Wrapper;
        public JoinActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Confirm => m_Wrapper.m_Join_Confirm;
        public InputAction @Cancel => m_Wrapper.m_Join_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_Join; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JoinActions set) { return set.Get(); }
        public void SetCallbacks(IJoinActions instance)
        {
            if (m_Wrapper.m_JoinActionsCallbackInterface != null)
            {
                @Confirm.started -= m_Wrapper.m_JoinActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_JoinActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_JoinActionsCallbackInterface.OnConfirm;
                @Cancel.started -= m_Wrapper.m_JoinActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_JoinActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_JoinActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_JoinActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public JoinActions @Join => new JoinActions(this);
    public interface IOrdersActions
    {
        void OnUknown(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnGather(InputAction.CallbackContext context);
        void OnFollow(InputAction.CallbackContext context);
    }
    public interface IConstructionActions
    {
        void OnPlace(InputAction.CallbackContext context);
        void OnBuild(InputAction.CallbackContext context);
        void OnPreview(InputAction.CallbackContext context);
        void OnSwapNext(InputAction.CallbackContext context);
        void OnSwapPrevious(InputAction.CallbackContext context);
    }
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IJoinActions
    {
        void OnConfirm(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
}
