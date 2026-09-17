using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int DeathCount { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RegisterDeath()
    {
        DeathCount++;
        Debug.Log($"Смертей: {DeathCount}");

        if (RoomManager.Instance != null)
            RoomManager.Instance.Respawn();
    }
}