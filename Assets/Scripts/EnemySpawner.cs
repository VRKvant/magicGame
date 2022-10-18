using UnityEngine;
using System.Collections.Generic;
public class EnemySpawner : MonoBehaviour
{
    private List<GameObject> _enemies = new List<GameObject>();
    public MainTarget Target 
    { 
        get 
        { 
            return _target; 
        } 
        set 
        { 
            _target = value;
            StartGame();
        } 
    }
    private MainTarget _target;
    [SerializeField] private List<GameObject> _enemiesPrefabs;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField, Range(0, 10)]
    private float _spawnRate;
    [SerializeField, Range(0, 10)]
    private int _maxNumberOfEnemies;
    [SerializeField] private PlanesManager _planes;
    public void StartGame()
    {
        _spawnPoint.gameObject.SetActive(true);
        _spawnPoint.position = _planes.WallCentre;
        _spawnPoint.rotation = _planes.MainWall.Rotation;
        InvokeRepeating(nameof(SpawnEnemy), 1f, _spawnRate);
        
    }
    private void SpawnEnemy()
    {
        if (_target == null) { return; }
        Enemy enemy;
        enemy = Instantiate(_enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Count)], _spawnPoint).GetComponent<Enemy>();
        enemy.Target = _target;
        _enemies.Add(enemy.gameObject);
    }
    public void Reload()
    {
        foreach (GameObject enemy in _enemies)
        {
            Destroy(enemy);
        }
        _spawnPoint.gameObject.SetActive(false);
        CancelInvoke(nameof(SpawnEnemy));
    }
}
