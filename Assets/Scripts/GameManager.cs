
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get => _instance;
    }

    [SerializeField] Transform frontLeftLowerBorder;
    [SerializeField] Transform backRightUpperBorder;

    public Transform FrontLeftLowerBorder
    {
        get => frontLeftLowerBorder;
    }
    public Transform BackRightUpperBorder
    {
        get => backRightUpperBorder;
    }

    private void Awake()
    {
        _instance = this;
    }
}