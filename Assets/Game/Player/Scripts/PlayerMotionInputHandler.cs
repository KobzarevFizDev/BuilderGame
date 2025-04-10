using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace BuilderGame.Player
{

    public class PlayerMotionInputHandler: ITickable
    {
        private PlayerMotionHandler _playerMotionHandler;
        private float _lookSens;
        private InputMaster _inputMaster;

        public PlayerMotionInputHandler(PlayerMotionHandler playerMotionHandler, float lookSens)
        {
            _playerMotionHandler = playerMotionHandler;
            _lookSens = lookSens;

            _inputMaster = new InputMaster();
            _inputMaster.Enable();
        }


        void ITickable.Tick()
        {
            ReadLookInput();
            ReadMoveInput();
        }

        private void ReadLookInput()
        {
            var lookInput = Mouse.current.delta.ReadValue();
            float deltaLookUp = lookInput.y * _lookSens;
            float deltaLookBackward = lookInput.x * _lookSens;

            _playerMotionHandler.HandleLookInput(deltaLookUp, deltaLookBackward);
        }

        private void ReadMoveInput()
        {
            var moveInput = _inputMaster.Player.Move.ReadValue<Vector2>();
            float moveForward = moveInput.y;
            float moveBackward = moveInput.x;

            _playerMotionHandler.HandleMoveInput(moveForward, moveBackward);
        }
    }
}
