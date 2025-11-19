using UnityEngine;
using UnityEngine.InputSystem;

public class PauseBehaviour : MonoBehaviour, InputSystem_Actions.IUIActions
{
    private InputSystem_Actions _actions;
    [SerializeField] private GameObject pauseMenu;
    private bool _paused = false;
    private void Awake()
    {
        _actions = new InputSystem_Actions();
        _actions.UI.SetCallbacks(this);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    private void OnEnable()
    {
        _actions.Enable();
    }
    private void OnDisable()
    {
        _actions.Disable();
    }
    private void TogglePause()
    {
        if (_paused)
            ResumeGame();
        else
            PauseGame();
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        _paused = true;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu?.SetActive(false);
        _paused = false;
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
            TogglePause();
    }
}
