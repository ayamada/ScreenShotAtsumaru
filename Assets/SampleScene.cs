using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleScene : MonoBehaviour {
    void Awake() {
        ScreenShotAtsumaru.Install();
    }

    public int dataA;
    public float dataB;
    public string dataC;

    private Text labelA;
    private Text labelB;
    private Text labelC;

    private void syncA()
    {
        labelA.text = dataA.ToString();
    }

    private void syncB()
    {
        labelB.text = dataB.ToString();
    }

    private void syncC()
    {
        labelC.text = dataC;
    }

    private void emitLoad () {
        dataA = PlayerPrefsAtsumaru.GetInt("dataA", 0);
        dataB = PlayerPrefsAtsumaru.GetFloat("dataB", 0);
        dataC = PlayerPrefsAtsumaru.GetString("dataC", "A");
        syncA();
        syncB();
        syncC();
    }

    private void emitSave () {
        ScreenShotAtsumaru.Snap();
    }

    // Use this for initialization
	void Start () {
        labelA = GameObject.Find("TextA").GetComponent<Text>();
        labelB = GameObject.Find("TextB").GetComponent<Text>();
        labelC = GameObject.Find("TextC").GetComponent<Text>();
        emitLoad();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnClickSave () {
        emitSave();
    }

    public void OnClickA () {
        dataA++;
        syncA();
    }

    public void OnClickB () {
        dataB += 0.1F;
        syncB();
    }

    public void OnClickC () {
        char ch = 'A';
        if (1 <= dataC.Length) {
            ch = dataC[0];
            ch++;
            if ('Z' < ch) {
                ch = 'A';
            }
        }
        dataC = ch.ToString();
        syncC();
    }
}
