using UnityEngine;
using System.Collections.Generic;


public class HumanAnimator : MonoBehaviour {

    [SerializeField] Human humanPrefab;
    [SerializeField] int count;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;
    [SerializeField] float zOffset;

    List<Human> humans;

    private void Awake() {
        humans = new List<Human>();
        for (int i = 0; i < count; i++) {
            var newHuman = GameObject.Instantiate<Human>(humanPrefab);
            newHuman.transform.position = new Vector3(xOffset, yOffset, zOffset * i);
            newHuman.transform.rotation = Quaternion.Euler(0, 90, 0);
            humans.Add(newHuman);
            newHuman = GameObject.Instantiate<Human>(humanPrefab);
            newHuman.transform.position = new Vector3(-xOffset, yOffset, zOffset * i);
            newHuman.transform.rotation = Quaternion.Euler(0, -90, 0);
            humans.Add(newHuman);
        }
    }

    private void Update() {
        foreach (Human human in humans) {
            human.UpdateLight();
        }
    }

}