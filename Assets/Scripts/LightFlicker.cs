using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LightFlicker : MonoBehaviour
{

public float timeOn;
public float timeOff;
private float changeTime = 0f;

public Behaviour halo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
{

if (Time.time > changeTime) {


halo.enabled = !halo.enabled;
 }
if (halo.enabled) {
changeTime = Time.time + timeOn;
} else {
changeTime = Time.time + timeOff;
}
}
}

