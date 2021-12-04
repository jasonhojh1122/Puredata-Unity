
using UnityEngine;

public class Ring : MonoBehaviour
{

    [SerializeField] float angularSpeed;

    private void Update()
    {
        transform.rotation = Quaternion.AngleAxis(
            angularSpeed * Time.deltaTime, transform.up) * transform.rotation;
    }

}