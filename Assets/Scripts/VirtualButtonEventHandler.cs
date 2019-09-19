/*============================================================================== 
 Copyright (c) 2016-2017 PTC Inc. All Rights Reserved.
 
 Copyright (c) 2012-2015 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using Vuforia;

/// <summary>
/// This class implements the IVirtualButtonEventHandler interface and
/// contains the logic to start animations depending on what 
/// virtual button has been pressed.
/// </summary>
public class VirtualButtonEventHandler : MonoBehaviour,
										 IVirtualButtonEventHandler
{
	#region PUBLIC_MEMBERS
	
	public Animator wand;
	public AudioSource audioENG;
	public AudioSource audioITA;
	public AudioSource audioHINDI;
	
	#endregion // PUBLIC_MEMBERS

	#region PRIVATE_MEMBERS
	VirtualButtonBehaviour[] virtualButtonBehaviours;
	#endregion // PRIVATE_MEMBERS

	#region MONOBEHAVIOUR_METHODS
	void Start()
	{
		// Register with the virtual buttons TrackableBehaviour
		virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

		for (int i = 0; i < virtualButtonBehaviours.Length; ++i)
		{
			virtualButtonBehaviours[i].RegisterEventHandler(this);
		}
        wand.GetComponent<Animator>();
		
	}

	#endregion // MONOBEHAVIOUR_METHODS


	#region PUBLIC_METHODS
	/// <summary>
	/// Called when the virtual button has just been pressed:
	/// </summary>
	public void OnButtonPressed(VirtualButtonBehaviour vb)
	{
		Debug.Log("OnButtonPressed: " + vb.VirtualButtonName);

        if(audioENG.isPlaying || audioHINDI.isPlaying || audioITA.isPlaying)
		{
			audioENG.Stop();
			audioITA.Stop();
			audioHINDI.Stop();
			
		}

		else
		{
			wand.Play("RotationAndAppearing");
			audioENG.Play();
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
