using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField] List<Texture2D> textures;
    [SerializeField] int TickInterval = 8;
    Renderer _renderer;
    MaterialPropertyBlock _prop;
    float minStep = 0.0001f;
    float maxStep = 0.99f;
    private void Awake() {
        _prop = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }

    public void ChangeBackground(float tick)
    {
        if ((int) tick % TickInterval == 0)
            StartCoroutine(ChangeAnim());
    }

    IEnumerator ChangeAnim()
    {
        float t = 0.0f;
        float durTick = TickInterval / 3;
        float halfDur = PDPlayer.Instance.Speed / 2000.0f * TickInterval;
        while (t < halfDur)
        {
            t += Time.deltaTime;
            float p = t / halfDur;
            _renderer.GetPropertyBlock(_prop);
            _prop.SetFloat("_Step", Mathf.Lerp(minStep, maxStep, p));
            _renderer.SetPropertyBlock(_prop);
            yield return null;
        }
        _renderer.GetPropertyBlock(_prop);
        _prop.SetTexture("_Text", textures[UnityEngine.Random.Range(0, textures.Count)]);
        _renderer.SetPropertyBlock(_prop);
        t = 0.0f;
        while (t < halfDur)
        {
            t += Time.deltaTime;
            float p = t / halfDur;
            _renderer.GetPropertyBlock(_prop);
            _prop.SetFloat("_Step", Mathf.Lerp(maxStep, minStep, p));
            _renderer.SetPropertyBlock(_prop);
            yield return null;
        }
            _renderer.GetPropertyBlock(_prop);
            _prop.SetFloat("_Step", minStep);
            _renderer.SetPropertyBlock(_prop);
    }
}
