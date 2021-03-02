using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputAction up;
    [SerializeField] private InputAction down;
    [SerializeField] private InputAction left;
    [SerializeField] private InputAction right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.

        if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            // 'Use' code here
        }

        Vector2 move = gamepad.leftStick.ReadValue();
        // 'Move' code here
        transform.Translate((new Vector3(move.x, 0f, move.y) * Time.deltaTime * 3f), Space.World);
    }
}
