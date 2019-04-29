using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
	public GameControllerInterface controllerInterface;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		gameObject.SetActive(false);
		controllerInterface.OnSpikeHit();	
	}
}
