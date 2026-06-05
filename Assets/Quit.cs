using UnityEngine;
using UnityEngine.InputSystem;

public class Quit : MonoBehaviour
{
    public InputActionReference uiQuit;

    private void OnEnable()
    {
        uiQuit.action.performed += OnQuit;
    }

    private void OnDisable()
    {
        uiQuit.action.performed -= OnQuit;
    }

    private static void OnQuit(InputAction.CallbackContext ctx) => Application.Quit();
}
