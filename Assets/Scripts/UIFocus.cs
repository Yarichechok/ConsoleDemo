using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIFocus : MonoBehaviour
{
    [SerializeField] private Selectable firstSelectable;

    void OnEnable()
    {
        if (firstSelectable != null)
            EventSystem.current.SetSelectedGameObject(firstSelectable.gameObject);
    }
}
