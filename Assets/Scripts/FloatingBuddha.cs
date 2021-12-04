
using UnityEngine;

public class FloatingBuddha : MonoBehaviour
{
    [SerializeField] float targetHeight;
    [SerializeField] float speedMultiplier = 0.5f;

    float startHeight;
    bool floatUp;

    private void Awake()
    {
        startHeight = transform.position.y;
        floatUp = true;
    }

    private void Update()
    {
        float speed = (targetHeight - startHeight) / PDPlayer.Instance.Speed * 1000.0f * speedMultiplier;
        Vector3 newPos = transform.position;
        if (floatUp)
        {
            newPos.y += speed * Time.deltaTime;
            if (newPos.y > targetHeight)
                floatUp = false;
        }
        else
        {
            newPos.y -= speed * Time.deltaTime;
            if (newPos.y < startHeight)
                floatUp = true;
        }
        transform.position = newPos;
    }

}