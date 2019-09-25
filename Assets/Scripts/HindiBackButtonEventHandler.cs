using UnityEngine;
using Vuforia;


public class HindiBackButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler
{
	#region PUBLIC_MEMBERS

	public GameObject EnglishReviews;
	public GameObject ItalianReviews;
	public GameObject HindiReviews;
	public GameObject ReviewButton;

	#endregion // PUBLIC_MEMBERS

	#region PRIVATE_MEMBERS
	VirtualButtonBehaviour[] virtualButtonBehaviours;

	int i;
	int k;
	GameObject[] childrenENG;
	GameObject[] childrenITA;
	GameObject[] childrenHINDI;
	#endregion // PRIVATE_MEMBERS

	#region MONOBEHAVIOUR_METHODS
	void Start()
	{


		childrenENG = GameObject.FindGameObjectsWithTag("EngRew");
		childrenITA = GameObject.FindGameObjectsWithTag("ItaRew");
		childrenHINDI = GameObject.FindGameObjectsWithTag("HindiRew");
		// Register with the virtual buttons TrackableBehaviour
		virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

		for (int j = 0; j < virtualButtonBehaviours.Length; ++j)
		{
			virtualButtonBehaviours[j].RegisterEventHandler(this);
		}

	}

	#endregion // MONOBEHAVIOUR_METHODS


	#region PUBLIC_METHODS
	/// <summary>
	/// Called when the virtual button has just been pressed:
	/// </summary>
	public void OnButtonPressed(VirtualButtonBehaviour vb)
	{
		k = ReviewButton.GetComponent<ReviewButtonEventHandler>().i;
		Debug.Log("OnButtonPressed: " + vb.VirtualButtonName);

		if (EnglishReviews.activeSelf)
		{
			EnglishReviews.SetActive(false);
			for (i = 0; i < 7; i++)
			{
				childrenHINDI[i].SetActive(false);
			}

			childrenHINDI[k].SetActive(true);
			HindiReviews.SetActive(true);


		}

		else if (ItalianReviews.activeSelf)
		{
			ItalianReviews.SetActive(false);
			
			for (i = 0; i < 7; i++)
			{
				childrenHINDI[i].SetActive(false);
			}
			childrenHINDI[k].SetActive(true);
			HindiReviews.SetActive(true);

		}

		else if (HindiReviews.activeSelf)
		{
			EnglishReviews.SetActive(true);
			HindiReviews.SetActive(false);
			for (i = 0; i < 7; i++)
			{
				childrenENG[i].SetActive(false);
			}
			childrenENG[k].SetActive(true);


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