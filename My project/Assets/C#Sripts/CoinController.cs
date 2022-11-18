using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
	//Variable for coin counter
	public int coin;

	public GameObject TextObject;
	Text textComponent;

	private void Start()
	{
		textComponent = TextObject.GetComponent<Text>();
	}
		//Will be started, if collider2D went into the trigger
		void OnTriggerEnter2D(Collider2D other)
		{
			//Checks, if gameObject has tag "Coins"
			if (other.tag == "Coins")
			{
				//Increment to the coin counter variable
				coin = coin + 1;
			//Transform int variable into string variable and assign the result to the text in the Text Component
			textComponent.text = coin.ToString();
				Destroy (other.gameObject);
			}
		}
}