using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class PDPlayer : MonoBehaviour {

    public LibPdInstance pdPatch;

    PDElement.BaseDrum baseDrum;
    PDElement.SnareDrum snareDrum;
    PDElement.HitHat hitHat;
    PDElement.Piano piano;
    PDElement.Sequencer sequencer;

    private void Awake() {
        baseDrum = new PDElement.BaseDrum(1, pdPatch, 6);
        snareDrum = new PDElement.SnareDrum(1, pdPatch, 6);
        hitHat = new PDElement.HitHat(1, pdPatch, 6);
        piano = new PDElement.Piano(1, pdPatch, 6);
        sequencer = new PDElement.Sequencer(1, pdPatch, 145);
        baseDrum.PlayPreset(1);
        snareDrum.PlayPreset(1);
        hitHat.PlayPreset(1);
        piano.PlayPreset(1);
    }

    private void Start() {
        sequencer.Toggle(true);
    }

    public void FloatReceive(string sender, float value) {
        if (sender == "OSC") {
            Debug.Log("1 " + value);
        }
    }
    public void FloatReceive2(string sender, float value) {
        if (sender == "OSC2") {
            Debug.Log("2 " + value);
        }
    }

}
