using System.Collections.Generic;
using UnityEngine;

public class PDPlayer : MonoBehaviour
{
    private static PDPlayer _instance;
    public static PDPlayer Instance
    {
        get => _instance;
    }

    [SerializeField] LibPdInstance pdPatch;
    [SerializeField] List<string> instruNames;
    [SerializeField] List<Human> humen;
    [SerializeField] SignalVisualizer signalVisualizer;
    [SerializeField] LaserLight laserLight;
    [SerializeField] Background background;
    public static readonly float TickStep = 15;
    Dictionary<string, Human> humanMap;
    Dictionary<string, PDElement.Instument> instruMap;
    PDElement.Sequencer sequencer;

    public LibPdInstance PdPatch
    {
        get => pdPatch;
    }
    public float Speed
    {
        get => sequencer.speed;
        set {
            sequencer.SetSpeed(value);
        }
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        instruMap = new Dictionary<string, PDElement.Instument>();
        humanMap = new Dictionary<string, Human>();

        for (int i = 0; i < instruNames.Count; i++)
        {
            instruMap.Add(instruNames[i], new PDElement.Instument(instruNames[i]));
            humanMap.Add(instruNames[i], humen[i]);
            humen[i].instruName = instruNames[i];
            pdPatch.Bind("UH_" + instruNames[i]);
        }
        sequencer = new PDElement.Sequencer(1, 145);

        pdPatch.Bind("U_SnapShot");
        pdPatch.Bind("U_Tick-1");
    }

    private void Start()
    {
        sequencer.Toggle(true);
        pdPatch.SendBang("U_Sample");
    }

    private void Update() {
        if (Input.GetMouseButtonDown(2))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                Human human = hit.collider.gameObject.GetComponent<Human>();
                if (human != null)
                {
                    human.RandomArmAnimation();
                    human.RandomLegAnimation();
                    instruMap[human.instruName].PlayRandomPreset();
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                Human human = hit.collider.gameObject.GetComponent<Human>();
                if (human != null)
                {
                    human.RandomArmAnimation();
                    human.RandomLegAnimation();
                    instruMap[human.instruName].PlayNextPreset();
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                Human human = hit.collider.gameObject.GetComponent<Human>();
                if (human != null)
                {
                    human.Stop();
                    instruMap[human.instruName].Stop();
                }
            }
        }
    }

    public void BangReceive(string sender)
    {
        var s = sender.Split('_');
        if (humanMap.ContainsKey(s[1]))
        {
            humanMap[s[1]].Hitted();
        }
    }
    public void FloatReceive(string sender, float value)
    {
        if (sender == "U_SnapShot")
        {
            signalVisualizer.Visualize(value);
        }
        else if (sender == "U_Tick-1")
        {
            laserLight.Randomize();
            background.ChangeBackground(value);
        }
    }

}