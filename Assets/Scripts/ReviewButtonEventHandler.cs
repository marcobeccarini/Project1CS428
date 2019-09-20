using UnityEngine;
using Vuforia;


public class ReviewButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler
{
	#region PUBLIC_MEMBERS

	public GameObject EnglishReviews;
	public GameObject ItalianReviews;
	public GameObject HindiReviews;
	public int i;
	#endregion // PUBLIC_MEMBERS

	#region PRIVATE_MEMBERS
	VirtualButtonBehaviour[] virtualButtonBehaviours;
	
	GameObject[] childrenENG;
	GameObject[] childrenITA;
	GameObject[] childrenHINDI;
	#endregion // PRIVATE_MEMBERS

	#region MONOBEHAVIOUR_METHODS
	void Start()
	{
		i = 0;
		childrenENG = GameObject.FindGameObjectsWithTag("EngRew");
	    childrenITA = GameObject.FindGameObjectsWithTag("ItaRew");
	    childrenHINDI = GameObject.FindGameObjectsWithTag("HindiRew");
	    // Register with the virtual buttons TrackableBehaviour
	    virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

		for (int j = 0; j < virtualButtonBehaviours.Length; ++j)
		{
			virtualButtonBehaviours[j].RegisterEventHandler(this);
		}

		EnglishReviews.SetActive(true);
		ItalianReviews.SetActive(false);
		HindiReviews.SetActive(false);

		

		for (i = 1; i < 5; i++)
		{
			childrenENG[i].SetActive(false);
		}

		for (i = 0; i < 5; i++)
		{
			childrenITA[i].SetActive(false);
		}

		for (i = 0; i < 5; i++)
		{
			childrenHINDI[i].SetActive(false);
		}
		i = 0;
	}

	#endregion // MONOBEHAVIOUR_METHODS


	#region PUBLIC_METHODS
	/// <summary>
	/// Called when the virtual button has just been pressed:
	/// </summary>
	public void OnButtonPressed(VirtualButtonBehaviour vb)
	{
		
		Debug.Log("OnButtonPressed: " + vb.VirtualButtonName);

		if (EnglishReviews.activeSelf)
		{
            
			childrenENG[i].SetActive(false);
			i++;
			if (i < 5)
			{
				childrenENG[i].SetActive(true);
				
			}

			else
			{
				childrenENG[0].SetActive(true);
				i = 0;
			}

		}

		else if (ItalianReviews.activeSelf)
		{
			childrenITA[i].SetActive(false);
			i++;
			if (i < 5)
			{
				
				childrenITA[i].SetActive(true);
				
			}

			else
			{
				childrenITA[0].SetActive(true);
				i = 0;
			}

				

		}

		else if (HindiReviews.activeSelf)
		{
			childrenHINDI[i].SetActive(false);
			i++;
			if (i < 5)
			{
				
				childrenHINDI[i].SetActive(true);
				
				
			}

			else
			{
				childrenHINDI[0].SetActive(true);
				i = 0;
			}
		}

	}

	/// <summary>
	/// Called when the virtual button has just been released:
	/// </summary>
	public void OnButtonReleased(VirtualButtonBehaviour vb)
	{
		Debug.Log("OnButtonReleased: " + vb.VirtualButtonName);
	}
	#endregion //PUBLIC_METHODS


}

