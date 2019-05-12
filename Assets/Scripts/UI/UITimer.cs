using System.Text;
using TMPro;
using UnityEngine;
using ValueObjects;

public class UITimer : MonoBehaviour
{
	public string format = "0.00";
	public TextMeshProUGUI text;
	public FloatObject time;

	public int framesSkip;

	private float displayedValue = -1;

	int frame;

	public void FixedUpdate()
	{
		if (frame <= 0)
		{
			frame += framesSkip;
			if (displayedValue != time.value)
			{
				displayedValue = time.value;
				text.text = displayedValue.ToString(format);
			}
		}
		else
		{
			frame--;
		}
	}
}
