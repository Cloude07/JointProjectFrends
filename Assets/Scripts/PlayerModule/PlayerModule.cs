using CloudeDev.Components;
using CloudeDev.InputSystemModule;
using CloudeDev.PlayerModule;
using UnityEngine;

namespace CloudeDev.Architecture
{
    public class PlayerModule : GameModule
    {
        [Listener]
        [SerializeField]
        private PlayerController character;

        [SerializeField]
        [Service, Listener]
        private readonly InputManager inputManager = new InputManager();

        [SerializeField]
        [Service, Listener]
        private CheckSurroundings checkSurroundings = new CheckSurroundings();

        [SerializeField]
        [Service, Listener]
        private FlipComponent flip = new FlipComponent();
    }
}
