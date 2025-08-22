using UnityEngine;

public interface IPlatformServices
{
    string GetUserName();
    void ShowSystemOverlay(string msg);
}

public static class Platform
{
    public static IPlatformServices Services =
#if UNITY_PS5
        new Ps5Services();
#elif UNITY_GAMECORE || UNITY_XBOXONE
        new XboxServices();
#elif UNITY_SWITCH
        new SwitchServices();
#else
        new PcServices();
#endif
}

class PcServices : IPlatformServices
{
    public string GetUserName() => System.Environment.UserName;
    public void ShowSystemOverlay(string msg)
    {
        Debug.Log("[PC overlay] " + msg);
    }
}

#if UNITY_PS5
class Ps5Services : IPlatformServices {
    public string GetUserName() => "PS5User";
    public void ShowSystemOverlay(string msg) { Debug.Log("[PS5 overlay] " + msg); }
}
#endif

#if UNITY_GAMECORE || UNITY_XBOXONE
class XboxServices : IPlatformServices {
    public string GetUserName() => "XboxUser";
    public void ShowSystemOverlay(string msg) { Debug.Log("[Xbox overlay] " + msg); }
}
#endif

#if UNITY_SWITCH
class SwitchServices : IPlatformServices {
    public string GetUserName() => "SwitchUser";
    public void ShowSystemOverlay(string msg) { Debug.Log("[Switch overlay] " + msg); }
}
#endif
