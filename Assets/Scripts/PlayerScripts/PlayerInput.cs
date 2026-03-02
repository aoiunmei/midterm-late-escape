using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlayerInput : MonoBehaviour
{
    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }

    public bool sprintHeld { get; private set; }
    public bool jumpPressed { get; private set; }
    public bool activatePressed { get; private set; }
    public bool shootPressed { get; private set; }

    private bool _clear;

    void Update()
    {
        ClearInputs();
        GetInputs();
    }

    private void FixedUpdate()
    {
        _clear = true;
    }

    private void GetInputs() 
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        sprintHeld = sprintHeld || Input.GetButton("Sprint");
        jumpPressed = jumpPressed || Input.GetButton("Jump");
        activatePressed = activatePressed || Input.GetKeyDown(KeyCode.E);
        shootPressed = shootPressed || Input.GetButtonDown("Fire1");
    }

    private void ClearInputs() 
    {
        if (!_clear) return;
        horizontal = 0f;
        vertical = 0f;
        mouseX = 0f;
        mouseY = 0f;
        sprintHeld = false;
        jumpPressed = false;
        activatePressed = false;
        shootPressed = false;
        _clear = false;
    }
}