using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PauseManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject overlay;
    [SerializeField] private TextMeshProUGUI overlayLabel;

    private InputAction _pause;
    private InputAction _resume;
    private InputAction _quit;

    void Awake()
    {
        _pause = new InputAction("Pause", InputActionType.Button, "<Keyboard>/escape");
        _resume = new InputAction("Resume", InputActionType.Button, "<Keyboard>/enter");
        _resume.AddBinding("<Keyboard>/space");

        _quit = new InputAction("Quit", InputActionType.Button, "<Keyboard>/q");
    }

    void OnEnable()
    {
        _pause.Enable(); _resume.Enable(); _quit.Enable();
        InputSystem.onDeviceChange += OnDeviceChange;
    }
    void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
        _pause.Disable(); _resume.Disable(); _quit.Disable();
    }

    void Update()
    {
        if (_pause.WasPerformedThisFrame()) SetPaused(true);
        if (_resume.WasPerformedThisFrame()) SetPaused(false);
        if (_quit.WasPerformedThisFrame()) Quit();
    }

    public void SetPaused(bool v)
    {
        if (overlay) overlay.SetActive(v);
        Time.timeScale = v ? 0f : 1f;

        if (overlayLabel)
        {
            if (v)
                overlayLabel.text = "Paused Ч натисн≥ть Enter щоб продовжити\n(Controller disconnected)\nўоб вийти Ч натисн≥ть Q";
            else
                overlayLabel.text = "";
        }
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void OnDeviceChange(InputDevice d, InputDeviceChange c)
    {
        if (d is Gamepad && (c == InputDeviceChange.Disconnected || c == InputDeviceChange.Removed))
            SetPaused(true);
    }
}
