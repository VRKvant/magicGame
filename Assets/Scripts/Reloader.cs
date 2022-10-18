using UnityEngine;
using UnityEngine.SceneManagement;

public class Reloader : MonoBehaviour, ISpell
{
    [SerializeField] private MainTargetSpawner _mainTargetSpawner;
    [SerializeField] private EnemySpawner _enemiesSpawner;
    private void Start()
    {
        _mainTargetSpawner = FindObjectOfType<MainTargetSpawner>();
        _enemiesSpawner = FindObjectOfType<EnemySpawner>();
        ReloadScene();
    }
    private void ReloadScene()
    {
        _enemiesSpawner.Reload();
        _mainTargetSpawner.Reload();
        Destroy(gameObject, 1f);
    }
}
