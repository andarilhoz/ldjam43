using System.Collections;
using System.Collections.Generic;
using Injection;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Models;

public class QuestionSceneManager : MonoBehaviour
{

	public Button option1;
	public Button option2;
	public Button option3;

	[Inject] protected PlayerStatus PlayerStatus;
	
	private void Awake()
	{
		AppContext.Inject(this);

		option1.onClick.AddListener(delegate
		{
			PlayerStatus.First.SetValueAndForceNotify(10);
		});
		
		option2.onClick.AddListener(delegate
		{
			PlayerStatus.Second.SetValueAndForceNotify(20);
		});
		
		option3.onClick.AddListener(delegate
		{
			PlayerStatus.Third.SetValueAndForceNotify(30);
		});
	}

}
