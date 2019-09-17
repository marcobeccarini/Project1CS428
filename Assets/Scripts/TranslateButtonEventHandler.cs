using UnityEngine;
using Vuforia;



public class TranslateButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject AndThePrisoner;
    public GameObject SottotitoloITALIANO;
    public GameObject JKRowling;
    public GameObject Scrittoda;
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
		SottotitoloITALIANO.SetActive(false);
		JKRowling.SetActive(true);
		Scrittoda.SetActive(false);
	}

	public void OnButtonPressed(VirtualButtonBehaviour vb)
	{
		//Debug.Log(vb.VirtualButtonName);
		Debug.Log("Button pressed!");

		switch (vb.VirtualButtonName)
		{
			case "TranslateButton":
				if (AndThePrisoner.activeSelf)
				{

                    AndThePrisoner.SetActive(false);
                    SottotitoloITALIANO.SetActive(true);
                    JKRowling.SetActive(false);
                    Scrittoda.SetActive(true);
                }
				else
				{
                    AndThePrisoner.SetActive(true);
                    SottotitoloITALIANO.SetActive(false);
                    JKRowling.SetActive(true);
                    Scrittoda.SetActive(false);

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

