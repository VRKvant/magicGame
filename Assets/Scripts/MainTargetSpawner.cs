using UnityEngine;
public class MainTargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _mainTargetPrefab;
    [SerializeField] private EnemySpawner _enemies = null;
    [SerializeField] private PlanesManager _planes;
    private GameObject _target;

    private void Start()
    {
        Invoke(nameof(Init), 3f);
    }
    private void Init()
    {
        Vector3 roomCentre = _planes.RoomCentre;
        _target = Instantiate(_mainTargetPrefab, roomCentre, Quaternion.identity);
        _target.GetComponent<MainTarget>().StartGame();
        if (_enemies) 
        { 
            _enemies.Target = _target.GetComponent<MainTarget>();
        }
    }
    public void Reload()
    {
        Destroy(_target);
        Vector3 roomCentre = _planes.RoomCentre;
        _target = Instantiate(_mainTargetPrefab, roomCentre, Quaternion.identity);
        _target.GetComponent<MainTarget>().StartGame();
        if (_enemies)
        {
            _enemies.Target = _target.GetComponent<MainTarget>();
        }
    }
}
