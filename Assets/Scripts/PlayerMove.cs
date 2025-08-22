using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInputActions _input;
    private Vector3 _cached;
    public float speed = 10f;

    void Awake() { _input = new PlayerInputActions(); }
    void OnEnable() { _input.Enable(); }
    void OnDisable() { _input.Disable(); }

    void Update()
    {
        var m = _input.Gameplay.Move.ReadValue<UnityEngine.Vector2>();
        _cached.x = m.x; _cached.y = 0f; _cached.z = m.y;
        transform.Translate(_cached * speed * Time.deltaTime, Space.World);
    }
}
