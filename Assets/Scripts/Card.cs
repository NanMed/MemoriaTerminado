using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour { 

	private bool _interactive;
	private bool _flip = true;

    //MY VARIABLES
    public GameMaster gm;

	// Use this for initialization
	void Start () {
		_interactive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		if(!_interactive)
		{
			return;
		}

        if(gm.gameObject.GetComponent<GameMaster>().turns == 0)
        {
            return;
        }            


        Flip();
        gm.DetecCards(this);

    }

	public void Flip()
	{
		_interactive = false;
		iTween.RotateTo(gameObject, iTween.Hash(
			"y", (_flip ? 0 : 180),
			"time", 1,
			"easetype",iTween.EaseType.easeInSine,
			"oncomplete", "EnableInteraction"
			));
		_flip = !_flip;
	}

	public void EnableInteraction()
	{
		_interactive = true;
	}

}
