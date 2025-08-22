using UnityEngine;
public class Boot : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;

        var msg = $"Demo started. Hello, {Platform.Services.GetUserName()}";
        Platform.Services.ShowSystemOverlay(msg);
        Debug.Log(msg);
    }
}
