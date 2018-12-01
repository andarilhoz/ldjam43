using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class BasicTest {

	[Test]
	public void ThereIsAGameManagerGameObject(){
		Assert.That(GameObject.Find("GameManager"));
	}

	[Test]
	public void ThereIsAGameManagerScriptAttachedToGame(){
		GameObject game = GameObject.Find("GameManager");
		Assert.That(game.GetComponent<AppContext>());
	}
}
