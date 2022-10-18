using UnityEngine;
using UnityEngine.VFX;
//[ExecuteAlways]
public class MagicOrbPulsating : MonoBehaviour
{

    [SerializeField] private float animationspeed = 0.5f;
    [SerializeField]private float endSize = 5;
    private VisualEffect visualEffect;
    private float startSize;
    static float t = 0.0f;

    // Start is called before the first frame update
    void OnEnable()
    {
        visualEffect = GetComponent<VisualEffect>();
        startSize = visualEffect.GetFloat("Size");
    }
    private void Start()
    {
        visualEffect = GetComponent<VisualEffect>();
        startSize = visualEffect.GetFloat("Size");
    }

    // Update is called once per frame
    void Update()
    {
        t += animationspeed * Time.deltaTime;
        visualEffect.SetFloat("Size", Mathf.Lerp(startSize, endSize, t));

        if (t > 1.0f)
        {
            float temp = endSize;
            endSize = startSize;
            startSize = temp;
            t = 0.0f;
        }
    }
}
