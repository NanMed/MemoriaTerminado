using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
	public GameObject[] Cards;

    //MY VARIABLES
    private Card card1;
    private Card card2;
    private int pairs;
    public int turns;
    public GameObject WinPanel;

	// Use this for initialization
	void Start (){
		SortCards();
		PlaceCards();
        pairs = 3;
        turns = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //This method receive the pair of cards.
    public void DetecCards(Card receviedCard)
    {
        if(card1 == null)
        {
            turns--;
            card1 = receviedCard;
        }
        else
        {
            turns--;
            card2 = receviedCard;
            StartCoroutine("CompareCards");
        }
    }

    //This method wait the card to be up and then, compares the cards.
    private IEnumerator CompareCards()
    {
        yield return new WaitForSeconds(2);
        if (card1.tag == card2.tag)
        {
            Destroy(card1.gameObject);
            Destroy(card2.gameObject);
            pairs--;
            CheckWin();
        }
        else
        {
            card1.Flip();
            card2.Flip();
        }
        card1 = null;
        card2 = null;
        turns = 2;
    }

    //This method checks if there are no more cards -> Determinate if you have won
    private void CheckWin()
    {
        if(pairs == 0)
        {
            WinPanel.SetActive(true);
        }
    }

    //Reset the whole game.
    public void PlayAgainBro()
    {
        SceneManager.LoadScene("Game");
    }


    void SortCards()
	{
		// https://en.wikipedia.org/wiki/Fisher-Yates_shuffle
		for (int i = 0; i < Cards.Length; i++)
		{
			int j = Random.Range(i, Cards.Length );

			GameObject temp = Cards[i];
			Cards[i] = Cards[j];
			Cards[j] = temp;
		}
	}

	void PlaceCards()
	{
		for (int i = 0; i < Cards.Length; i++)
		{
			int row = Mathf.FloorToInt( i / 3 );
			int col = i % 3;

			float x = -4f + (4 * col);
			float y = -2.5f + (-5 * row);

			Vector3 position = new Vector3(x, y, 0);
			Cards[i].transform.localPosition = position;
		}
	}
}
