using UnityEngine;
using ValueObjects;

public class GameController : MonoBehaviour
{
	public ActionVoidObject onStartEntered;
	public ActionVoidObject onFinishEntered;

	public Timer timer;

	public GameControllerInterface controllerInterface;


	private void Awake()
	{
		Application.targetFrameRate = 60;
		controllerInterface.Restart();

		timer.RestartTimer();
		onStartEntered.AddListener(OnStartEntered);
		onFinishEntered.AddListener(OnFinishEntered);
	}


	void OnStartEntered()
	{
		timer.StartTimer();
		onStartEntered.RemoveListener(OnStartEntered);
	}

	void OnFinishEntered()
	{
		timer.Stop();
		onFinishEntered.RemoveListener(OnFinishEntered);
	}
}
