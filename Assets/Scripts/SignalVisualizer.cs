
using UnityEngine;

public class SignalVisualizer : MonoBehaviour
{

    [SerializeField] Renderer _renderer;
    [SerializeField] float vAmountMultiplier = 2;

    MaterialPropertyBlock _propBlock;

    private void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
    }

    public void Visualize(float shape)
    {
        _propBlock.SetFloat("_VAmount", shape * vAmountMultiplier);
        _renderer.SetPropertyBlock(_propBlock);
    }


}