using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    float spawnTimeDelay;
    float levelTimer;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(Instance);

        DontDestroyOnLoad(Instance);
    }

    private void Start()
    {
        levelTimer = 20f;
        spawnTimeDelay = 1f;
    }

    private void Update()
    {
        levelTimer += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")
                    Destroy(hit.collider.gameObject);
            }
        }

    }

    public float GetSpawnTimeDelay()
    {
        return spawnTimeDelay;
    }
}
