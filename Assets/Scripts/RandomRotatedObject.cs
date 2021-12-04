using UnityEngine;

public class RandomRotatedObject : MonoBehaviour {

    [SerializeField] float speed;
    Quaternion target;

    private void Start()
    {
        StartCoroutine(RandomRotate());
    }

    System.Collections.IEnumerator RandomRotate()
    {
        while (true)
        {
            target = Random.rotation;
            yield return StartCoroutine(RotateToTarget());
        }
    }

    System.Collections.IEnumerator RotateToTarget()
    {
        while (Quaternion.Angle(transform.localRotation, target) > 0.1f)
        {
            transform.localRotation = Quaternion.RotateTowards(
                    transform.localRotation, target, speed * Time.deltaTime);
            yield return null;
        }
    }



}