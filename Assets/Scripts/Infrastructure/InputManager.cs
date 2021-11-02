using UnityEngine;

namespace GizmoLab.Infrastructure
{
    public static class InputManager
    {
        #region Consts

        private const string HORIZONTAL_AXIS_NAME = "Horizontal";
        
        private const string VERTICAL_AXIS_NAME = "Vertical";

        private const KeyCode FIRE_REQUEST_BUTTON = KeyCode.Space;
        
        #endregion
        
        #region Methods

        public static float GetRotationInput()
        {
            return Input.GetAxisRaw(HORIZONTAL_AXIS_NAME);
        }

        public static float GetMovementInput()
        {
            return Input.GetAxisRaw(VERTICAL_AXIS_NAME);
        }

        public static bool IsFireRequested()
        {
            return Input.GetKeyDown(FIRE_REQUEST_BUTTON);
        }

        #endregion
    }
}