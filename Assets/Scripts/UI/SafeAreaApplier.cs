using UnityEngine;

[ExecuteAlways]
public class SafeAreaApplier : MonoBehaviour
{
    [Tooltip("яку панель п≥дган€ти. якщо порожньо Ч в≥зьме власний RectTransform")]
    public RectTransform panel;

    [Range(0f, 0.2f)]
    [Tooltip("‘олбек-/симул€ц≥€: в≥дступи по кра€х у % в≥д розм≥ру екрана, €кщо SafeArea = повний екран (наприклад на ѕ )")]
    public float fallbackPaddingPercent = 0f;

    Rect _lastSafe;
    Vector2Int _lastRes;

    void Reset() { panel = GetComponent<RectTransform>(); }
    void OnEnable() => Apply();
    void OnRectTransformDimensionsChange() => Apply();

#if UNITY_EDITOR
    void Update()
    {
        if (_lastRes.x != Screen.width || _lastRes.y != Screen.height) Apply();
    }
#endif

    void Apply()
    {
        if (panel == null) panel = GetComponent<RectTransform>();
        if (panel == null) return;

        var safe = Screen.safeArea;

        if ((int)safe.width == Screen.width && (int)safe.height == Screen.height && fallbackPaddingPercent > 0f)
        {
            float padX = Screen.width * fallbackPaddingPercent;
            float padY = Screen.height * fallbackPaddingPercent;
            safe = new Rect(padX, padY, Screen.width - 2 * padX, Screen.height - 2 * padY);
        }

        if (safe == _lastSafe && _lastRes.x == Screen.width && _lastRes.y == Screen.height) return;
        _lastSafe = safe; _lastRes = new Vector2Int(Screen.width, Screen.height);

        var min = safe.position;
        var max = safe.position + safe.size;
        min.x /= Screen.width; min.y /= Screen.height;
        max.x /= Screen.width; max.y /= Screen.height;

        panel.anchorMin = min;
        panel.anchorMax = max;
        panel.offsetMin = Vector2.zero;
        panel.offsetMax = Vector2.zero;
    }
}
