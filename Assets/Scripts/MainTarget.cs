using UnityEngine;
public class MainTarget : MonoBehaviour
{
    [SerializeField, Range(0, 100)]
    private int _maxHealth;
    private int _curHealth;
    [SerializeField] private GameObject _destructedPrefab;
    public void StartGame()
    {
        _curHealth = _maxHealth;

    }
    public void TakeDamage(int damage)
    {
        if(_curHealth > damage)
        {
            _curHealth -= damage;
        }
        else if (_curHealth <= damage)
        {
            _curHealth = 0;
            Die();
        }
    }
    private void Die()
    {
        if(_destructedPrefab) Instantiate(_destructedPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
