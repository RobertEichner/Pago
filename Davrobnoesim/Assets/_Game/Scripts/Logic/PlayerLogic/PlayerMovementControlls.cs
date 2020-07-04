// GENERATED AUTOMATICALLY FROM 'Assets/_Game/Scripts/Logic/PlayerLogic/PlayerMovementControlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerMovementControlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerMovementControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerMovementControlls"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""57b3bd44-b591-4e41-a31d-92be0013ced2"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""11f129a6-2972-49cb-8c64-a147edd87249"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""f0a0144c-d2b7-40f8-91f9-1fae86ce025d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HotbarAttackLeft"",
                    ""type"": ""Button"",
                    ""id"": ""d93dee37-59b5-433d-98f0-d5a074ba3d05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HotbarAttackRight"",
                    ""type"": ""Button"",
                    ""id"": ""4706f840-fb3c-427c-b97a-b9e1a417cd90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventarOpen"",
                    ""type"": ""Button"",
                    ""id"": ""8079d7c8-6aa1-4886-b57a-fec8ea9703af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""22e4606f-c70f-4656-b11e-d1454ffa9462"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7653c075-3151-4d71-85b7-e8d9bea2f74b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""98e30ea0-80fa-41f9-a35a-ec5066375dba"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""89dca1ca-1881-4572-8d33-885273ff881a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c3691436-2a17-41fa-a4b5-cf15ddaf6c96"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""14fbf9c1-1586-4505-91b7-ebf256ac40ca"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9751c8ca-c17d-4125-afcc-ebdcc43eb788"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29148a1e-56b7-474c-a1a7-d9314358f2d7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotbarAttackLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ccd30b5-a696-4366-a73f-76f8c6e801c7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotbarAttackRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f403b7c8-62ea-40b4-9d76-30dd1f30bd7c"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventarOpen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9db3bae3-e210-44a5-81eb-98cb79a9935c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_Interact = m_PlayerMovement.FindAction("Interact", throwIfNotFound: true);
        m_PlayerMovement_HotbarAttackLeft = m_PlayerMovement.FindAction("HotbarAttackLeft", throwIfNotFound: true);
        m_PlayerMovement_HotbarAttackRight = m_PlayerMovement.FindAction("HotbarAttackRight", throwIfNotFound: true);
        m_PlayerMovement_InventarOpen = m_PlayerMovement.FindAction("InventarOpen", throwIfNotFound: true);
        m_PlayerMovement_Escape = m_PlayerMovement.FindAction("Escape", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_Interact;
    private readonly InputAction m_PlayerMovement_HotbarAttackLeft;
    private readonly InputAction m_PlayerMovement_HotbarAttackRight;
    private readonly InputAction m_PlayerMovement_InventarOpen;
    private readonly InputAction m_PlayerMovement_Escape;
    public struct PlayerMovementActions
    {
        private @PlayerMovementControlls m_Wrapper;
        public PlayerMovementActions(@PlayerMovementControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Interact => m_Wrapper.m_PlayerMovement_Interact;
        public InputAction @HotbarAttackLeft => m_Wrapper.m_PlayerMovement_HotbarAttackLeft;
        public InputAction @HotbarAttackRight => m_Wrapper.m_PlayerMovement_HotbarAttackRight;
        public InputAction @InventarOpen => m_Wrapper.m_PlayerMovement_InventarOpen;
        public InputAction @Escape => m_Wrapper.m_PlayerMovement_Escape;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Interact.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnInteract;
                @HotbarAttackLeft.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnHotbarAttackLeft;
                @HotbarAttackLeft.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnHotbarAttackLeft;
                @HotbarAttackLeft.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnHotbarAttackLeft;
                @HotbarAttackRight.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnHotbarAttackRight;
                @HotbarAttackRight.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnHotbarAttackRight;
                @HotbarAttackRight.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnHotbarAttackRight;
                @InventarOpen.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnInventarOpen;
                @InventarOpen.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnInventarOpen;
                @InventarOpen.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnInventarOpen;
                @Escape.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @HotbarAttackLeft.started += instance.OnHotbarAttackLeft;
                @HotbarAttackLeft.performed += instance.OnHotbarAttackLeft;
                @HotbarAttackLeft.canceled += instance.OnHotbarAttackLeft;
                @HotbarAttackRight.started += instance.OnHotbarAttackRight;
                @HotbarAttackRight.performed += instance.OnHotbarAttackRight;
                @HotbarAttackRight.canceled += instance.OnHotbarAttackRight;
                @InventarOpen.started += instance.OnInventarOpen;
                @InventarOpen.performed += instance.OnInventarOpen;
                @InventarOpen.canceled += instance.OnInventarOpen;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnHotbarAttackLeft(InputAction.CallbackContext context);
        void OnHotbarAttackRight(InputAction.CallbackContext context);
        void OnInventarOpen(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
    }
}
