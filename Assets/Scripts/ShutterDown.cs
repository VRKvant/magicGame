using UnityEngine;
using UnityEngine.SceneManagement;

public class ShutterDown : MonoBehaviour, ISpell
{
    
    private void Start()
    {
        Application.Quit();
    }
}
