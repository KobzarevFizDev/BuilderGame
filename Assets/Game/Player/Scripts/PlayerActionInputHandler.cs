using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BuilderGame.Player
{
    public class PlayerActionInputHandler : ILateDisposable, ITickable
    {
        //private InputMaster _inputMaster;
        //private PlayerActionHandler _playerActionHandler;

        //private Transform _handItemPreview;

        //public PlayerActionInputHandler(PlayerActionHandler playerActionHandler, Transform handItemPreview)
        //{
        //    _inputMaster = new InputMaster();

        //    _inputMaster.Enable();
        //    _inputMaster.Player.Enable();

        //    _inputMaster.Player.ThrowBottle.performed += ThrowBottle;

        //    _playerActionHandler = playerActionHandler;
        //    _handItemPreview = handItemPreview;
        //}

        //private void ThrowBottle(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        //{
        //    _playerActionHandler.ThrowBottle(_handItemPreview);
        //}

        //void ILateDisposable.LateDispose()
        //{
        //    _inputMaster.Player.ThrowBottle.performed -= ThrowBottle;
        //}

        //void ITickable.Tick()
        //{
        //    //_playerActionHandler.ThrowBottle(_handItemPreview);
        //}
        void ILateDisposable.LateDispose()
        {
            throw new System.NotImplementedException();
        }

        void ITickable.Tick()
        {
            throw new System.NotImplementedException();
        }
    }
}
