
using UnityEngine;

public class Human : MonoBehaviour {

    [SerializeField] Transform LookAt;
    [SerializeField] Transform LeftArmTarget;
    [SerializeField] Transform RightArmTarget;
    [SerializeField] Transform LeftLegTarget;
    [SerializeField] Transform RightLegTarget;
    [SerializeField] Transform Lights;

    public void UpdateLight() {
        Lights.rotation = Quaternion.AngleAxis(10 * Time.deltaTime, Vector3.up) * Lights.rotation;
    }

}