
using UnityEngine;
using System.Collections.Generic;

public class LaserLight : MonoBehaviour
{
    [SerializeField] float width;
    [SerializeField] float lightCnt;
    [SerializeField] LineRenderer laserPrefab;
    List<LineRenderer> lineRenderers;
    MaterialPropertyBlock _property;

    private void Awake()
    {
        lineRenderers = new List<LineRenderer>();
        for (int i = 0; i < lightCnt; i++)
        {
            var lr = GameObject.Instantiate<LineRenderer>(laserPrefab);
            lr.positionCount = 2;
            lr.startWidth = width;
            lr.endWidth = width;
            lr.SetPosition(0, GameManager.Instance.BackRightUpperBorder.position);
            lr.SetPosition(1, GameManager.Instance.FrontLeftLowerBorder.position);
            lineRenderers.Add(lr);
        }
        _property = new MaterialPropertyBlock();
    }

    private void Start()
    {
        Randomize();
    }

    public void Randomize()
    {
        for (int i = 0; i < lineRenderers.Count; i++)
        {
            lineRenderers[i].SetPosition(0, RandomPos(GameManager.Instance.FrontLeftLowerBorder.position.y));
            lineRenderers[i].SetPosition(1, RandomPos(GameManager.Instance.BackRightUpperBorder.position.y));
            lineRenderers[i].GetPropertyBlock(_property);
            _property.SetFloat("_Seed", (i + Time.deltaTime) * Time.time);
            lineRenderers[i].SetPropertyBlock(_property);
        }
    }

    public Vector3 RandomPos(float height)
    {
        float x = UnityEngine.Random.Range(GameManager.Instance.FrontLeftLowerBorder.position.x,
            GameManager.Instance.BackRightUpperBorder.position.x);
        float z = UnityEngine.Random.Range(GameManager.Instance.FrontLeftLowerBorder.position.z,
            GameManager.Instance.BackRightUpperBorder.position.z);
        return new Vector3(x, height, z);
    }
}