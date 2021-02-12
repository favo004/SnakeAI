using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public enum Control
    {
        Left,
        Right,
        Up,
        Down
    }
    /// <summary>
    /// Manages all input for the game
    /// </summary>
    public class InputMananger
    {
        private ControlBounds controlBounds;

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public InputMananger()
        {
            controlBounds = new ControlBounds();

            controlBounds.AddKeyBinding(Control.Down, Keys.Down);
            controlBounds.AddKeyBinding(Control.Left, Keys.Left);
            controlBounds.AddKeyBinding(Control.Right, Keys.Right);
            controlBounds.AddKeyBinding(Control.Up, Keys.Up);

            
        }

        public void Update(GameTime gameTime)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState(); 
        }
        /// <summary>
        /// Checks to see if control has been pressed
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public bool IsKeyPressed(Control control)
        {
            var keyToCheck = controlBounds.DoesContainControl(control);
            if(keyToCheck != null)
            {
                if(currentKeyboardState.IsKeyUp(keyToCheck.Key) &&
                    previousKeyboardState.IsKeyDown(keyToCheck.Key))
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Checks to see if control is being held
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public bool IsKeyHeld(Control control)
        {
            var keyToCheck = controlBounds.DoesContainControl(control);
            if (keyToCheck != null)
            {
                if (currentKeyboardState.IsKeyDown(keyToCheck.Key) &&
                    previousKeyboardState.IsKeyDown(keyToCheck.Key))
                {
                    return true;
                }
            }

            return false;
        }
    }

    /// <summary>
    /// Stores keybindings for game controls
    /// </summary>
    public class ControlBounds
    {
        private List<KeyBinding> keyBindings;

        public ControlBounds()
        {
            keyBindings = new List<KeyBinding>();
        }

        /// <summary>
        /// Adds or updates existing key binding 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="key"></param>
        public void AddKeyBinding(Control control, Keys key)
        {
            KeyBinding kb = DoesContainControl(control);

            if (kb == null)
                kb = new KeyBinding();

            kb.SetControl(control, key);
        }

        /// <summary>
        /// Checks current keybindings if control binding exists
        /// </summary>
        /// <param name="control"></param>
        public KeyBinding DoesContainControl(Control control)
        {
            return keyBindings.FirstOrDefault(k => k.Control == control);
        }
    }

    public class KeyBinding
    {
        public Control Control;
        public Keys Key;

        public KeyBinding()
        {

        }
        public KeyBinding(Control control, Keys key)
        {
            SetControl(control, key);
        }

        public void SetControl(Control control, Keys newKey)
        {
            Control = control;
            Key = newKey;
        }

    }
}
