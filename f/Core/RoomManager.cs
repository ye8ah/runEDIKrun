using System.Collections;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;

    [SerializeField] private Transform player;
    [SerializeField] private float respawnDelay = 0.3f;

    private Vector2 spawnPoint;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }
        spawnPoint = player != null ? (Vector2)player.position : Vector2.zero;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnRoutine());
    }

    private IEnumerator RespawnRoutine()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);

        player.position = spawnPoint;
        player.gameObject.SetActive(true);
    }

    public void SetSpawnPoint(Vector2 pos) => spawnPoint = pos;
}