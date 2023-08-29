using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] InputAction m_rollInput = new(InputType.GetKeyDown, KeyCode.Space);
    Vector2 m_moveDir;
    public Vector2 m_MoveDir => m_moveDir;
    public Vector2 m_MousePosition => Input.mousePosition;


    private void Update()
    {
        SetMoveDir();
        m_rollInput.Action();
    }

    void SetMoveDir()
    {
        m_moveDir.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}


[System.Serializable]
public class InputAction
{
    [SerializeField] InputType m_inputType;
    [SerializeField] KeyCode m_inputKeyCode;
    [SerializeField] UnityEvent m_action;

    public InputAction(InputType inputType, KeyCode inputKeyCode)
    {
        m_inputType = inputType;
        m_inputKeyCode = inputKeyCode;
    }

    public bool Action()
    {
        bool action = InputCheck();

        if (action)
        {
            m_action?.Invoke();
        }

        return action;
    }

    bool InputCheck()
    {
        switch (m_inputType)
        {
            case InputType.GetKey:
                return Input.GetKey(m_inputKeyCode);
            case InputType.GetKeyDown:
                return Input.GetKeyDown(m_inputKeyCode);
            case InputType.GetKeyUp:
                return Input.GetKeyUp(m_inputKeyCode);
            default:
                return false;
        }
    }
}
public enum InputType
{
    GetKey, GetKeyDown, GetKeyUp
}
