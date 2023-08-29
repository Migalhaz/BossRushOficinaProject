using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PlayerInputs : MonoBehaviour
{
    [Header("Components")]
    Camera m_mainCamera;

    [Header("Input Actions")]
    [SerializeField] InputAction m_rollInput = new(InputType.GetKeyDown, KeyCode.Space);
    [SerializeField] MouseInputAction m_shootInput = new(InputType.GetKey, 0);

    [Header("Vectors")]
    Vector2 m_moveDir;

    #region Getters
    public Vector2 m_MoveDir => m_moveDir;
    public Vector2 m_MousePosition => Input.mousePosition;
    #endregion
    private void Start()
    {
        m_mainCamera = PlayerManager.Instance.m_MainCamera;
    }

    private void Update()
    {
        SetMoveDir();
        m_rollInput.Action();
        m_shootInput.Action();
    }

    void SetMoveDir()
    {
        m_moveDir.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public Vector3 MouseWorldPosition()
    {
        return m_mainCamera.ScreenToWorldPoint(m_MousePosition);
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

[System.Serializable]
public class MouseInputAction
{
    [SerializeField] InputType m_inputType;
    [SerializeField, Range(0, 2)] int m_mouseButton;
    [SerializeField] UnityEvent m_action;

    public MouseInputAction(InputType inputType, int mouseButton)
    {
        m_inputType = inputType;
        m_mouseButton = mouseButton;
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
                return Input.GetMouseButton(m_mouseButton);
            case InputType.GetKeyDown:
                return Input.GetMouseButtonDown(m_mouseButton);
            case InputType.GetKeyUp:
                return Input.GetMouseButtonUp(m_mouseButton);
            default:
                return false;
        }
    }
}
public enum InputType
{
    GetKey, GetKeyDown, GetKeyUp
}
