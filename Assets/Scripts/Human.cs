
using UnityEngine;

public class Human : MonoBehaviour
{

    [SerializeField] Transform LookAt;
    [SerializeField] Animator armAnimator;
    [SerializeField] Animator legAnimator;
    [SerializeField] SkinnedMeshRenderer smr;
    [SerializeField] float hitDur = 0.1f;
    [SerializeField] float randPosAmount = 0.1f;
    [SerializeField] int armAnimCnt;
    [SerializeField] int legAnimCnt;
    MaterialPropertyBlock _propBlock;

    public string instruName;
    Vector3 idleLookAt;
    Vector3 targetLookAt;

    private void Awake() {
        _propBlock = new MaterialPropertyBlock();
        idleLookAt = LookAt.position;
    }

    public virtual void RandomArmAnimation()
    {
        armAnimator.SetInteger("type", UnityEngine.Random.Range(1, armAnimCnt+1));
    }

    public virtual void StopArmAnimation()
    {
        armAnimator.SetInteger("type", 0);
    }

    public virtual void RandomLegAnimation()
    {
        legAnimator.SetInteger("type", UnityEngine.Random.Range(1, legAnimCnt+1));
    }
    public virtual void StopLegAnimation()
    {
        legAnimator.SetInteger("type", 0);
    }

    public void Stop()
    {
        StopArmAnimation();
        StopLegAnimation();
        targetLookAt = idleLookAt;
        StartCoroutine(Look());
    }

    bool hitted;

    public void Hitted()
    {
        targetLookAt = RandomPos();
        StartCoroutine(HitAnim());
        StartCoroutine(Look());
    }

    System.Collections.IEnumerator HitAnim()
    {
        float t = 0.0f;
        while (t < hitDur)
        {
            t += Time.deltaTime;
            float p;
            if (t < hitDur/2)
                p = t * 2 / hitDur;
            else
                p = 2 - t * 2 / hitDur;
            _propBlock.SetFloat("_RandPosAmount", p * randPosAmount);
            smr.SetPropertyBlock(_propBlock);
            yield return null;
        }
        _propBlock.SetFloat("_RandPosAmount", 0);
        smr.SetPropertyBlock(_propBlock);
        RandomArmAnimation();
        RandomLegAnimation();
    }

    System.Collections.IEnumerator Look()
    {
        float t = 0.0f;
        Vector3 initLookAt = LookAt.position;
        while (t < hitDur)
        {
            t += Time.deltaTime;
            float p = t / hitDur;
            LookAt.position = Vector3.Lerp(initLookAt, targetLookAt, p);
            yield return null;
        }
    }

    public Vector3 RandomPos()
    {
        float x = UnityEngine.Random.Range(GameManager.Instance.FrontLeftLowerBorder.position.x,
            GameManager.Instance.BackRightUpperBorder.position.x);
        float y = UnityEngine.Random.Range(GameManager.Instance.FrontLeftLowerBorder.position.y,
            GameManager.Instance.BackRightUpperBorder.position.y);
        float z = UnityEngine.Random.Range(GameManager.Instance.FrontLeftLowerBorder.position.z,
            GameManager.Instance.BackRightUpperBorder.position.z);
        return new Vector3(x, y, z);
    }

}