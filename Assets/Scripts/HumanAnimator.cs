using UnityEngine;
using System.Collections.Generic;


public class HumanAnimator : MonoBehaviour
{

    [SerializeField] int ArmAnimCnt;
    [SerializeField] int LegAnimCnt;
    [SerializeField] List<Human> humen;
    [SerializeField] float waitTime;

    private void Start()
    {
        StartCoroutine(RandomAnim());
    }

    System.Collections.IEnumerator RandomAnim()
    {
        while (true)
        {
            foreach (Human human in humen)
            {
                human.RandomArmAnimation();
                human.RandomLegAnimation();
            }
            yield return new WaitForSeconds(waitTime);
        }
    }

}