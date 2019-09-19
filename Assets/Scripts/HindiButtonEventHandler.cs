﻿using UnityEngine;
using Vuforia;



public class HindiButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler
{


    public GameObject AndThePrisoner;
    public GameObject SottotitoloITALIANO;
    public GameObject JKRowling;
    public GameObject Scrittoda;
    public GameObject SottotitoloHindi;
    public GameObject WrittenHindi;
	public AudioSource audioENG;
	public AudioSource audioITA;
	public AudioSource audioHINDI;


	// Private fields to store the models
	VirtualButtonBehaviour[] virtualButtonBehaviours;

    void Start()
    {

        // Search for all Children from this ImageTarget with type VirtualButtonBehaviour
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < virtualButtonBehaviours.Length; ++i)
        {
            virtualButtonBehaviours[i].RegisterEventHandler(this);
        }



        // Find the models based on the names in the Hierarchy
        AndThePrisoner.SetActive(true);
        JKRowling.SetActive(true);
        SottotitoloITALIANO.SetActive(false);
        Scrittoda.SetActive(false);
        SottotitoloHindi.SetActive(false);
        WrittenHindi.SetActive(false);
		audioITA.Stop();
		audioHINDI.Stop();

	}

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        //Debug.Log(vb.VirtualButtonName);
        Debug.Log("Button pressed!");

        switch (vb.VirtualButtonName)
        {
            case "HindiButton":
                if (AndThePrisoner.activeSelf || SottotitoloITALIANO.activeSelf)
                {

                    AndThePrisoner.SetActive(false);
                    WrittenHindi.SetActive(true);
                    SottotitoloHindi.SetActive(true);
                    JKRowling.SetActive(false);
                    SottotitoloITALIANO.SetActive(false);
                    Scrittoda.SetActive(false);
					if (audioITA.isPlaying || audioENG.isPlaying)
					{
						audioENG.Stop();
						audioITA.Stop();
						audioHINDI.Play();

					}



				}
				else
                {
                    AndThePrisoner.SetActive(true);
                    SottotitoloITALIANO.SetActive(false);
                    JKRowling.SetActive(true);
                    Scrittoda.SetActive(false);
                    WrittenHindi.SetActive(false);
                    SottotitoloHindi.SetActive(false);
					audioITA.Stop();
					audioHINDI.Stop();
					audioENG.Play();


				}
                //it work when i press VB, but how to disable again when i press VB again ?

                break;

                // default:
                // throw new UnityException("Button not supported: " + vb.VirtualButtonName);
                // break;

        }

    }

    /// Called when the virtual button has just been released:
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button released!");
    }

}

