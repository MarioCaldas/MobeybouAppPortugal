///-----------------------------------------------------------------
///   Class:          GameStateController
///   Description:    Handles the current state of the game and whos turn it is
///   Author:         VueCode
///   GitHub:         https://github.com/ivuecode/
///-----------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    [Header("TitleBar References")]
    public Image playerXIcon;                                        // Reference to the playerX icon
    public Image playerOIcon;                                        // Reference to the playerO icon
    public InputField player1InputField;                             // Reference to P1 input field
    public InputField player2InputField;                             // Refernece to P2 input field
    public Text winnerText;                                          // Displays the winners name

    [Header("Misc References")]
    public GameObject endGameState;                                  // Game footer container + winner text

    [Header("Asset References")]
    public Sprite tilePlayerO;                                       // Sprite reference to O tile
    public Sprite tilePlayerX;                                       // Sprite reference to X tile
    public Sprite tileEmpty;                                         // Sprite reference to empty tile
    public Text[] tileList;                                          // Gets a list of all the tiles in the scene

    [Header("GameState Settings")]
    public Color inactivePlayerColor;                                // Color to display for the inactive player icon
    public Color activePlayerColor;                                  // Color to display for the active player icon
    public string whoPlaysFirst;                                     // Who plays first (X : 0) {NOTE! no checks are made to ensure this is either X or O}

    [Header("Private Variables")]
    private string playerTurn;                                       // Internal tracking whos turn is it
    private string player1Name;                                      // Player1 display name
    private string player2Name;                                      // Player2 display name
    private int moveCount;                                           // Internal move counter
    private string previousPlayerTurn;                                       // Internal tracking whos turn is it

    public enum GameType { Pvp, Pvc };

    public GameType gameType;

    public DragController dragController;

    public PlayerOption XplayerOption;
    public PlayerOption OplayerOption;

    [Header("Audio")]
    [SerializeField] public AudioClip endSound;
    [SerializeField] public AudioSource aS;

    /// <summary>
    /// Start is called on the first active frame
    /// </summary>
    private void Start()
    {
        // Set the internal tracker of whos turn is first and setup UI icon feedback for whos turn it is
        playerTurn = whoPlaysFirst;
        if (playerTurn == "X")
        {
            XplayerOption.GetComponent<Image>().color = activePlayerColor;
            OplayerOption.GetComponent<Image>().color = inactivePlayerColor;
            playerOIcon.color = inactivePlayerColor;
            XplayerOption.interactable = true;
        }
        else
        {
            XplayerOption.GetComponent<Image>().color = inactivePlayerColor;
            OplayerOption.GetComponent<Image>().color = activePlayerColor;
            playerXIcon.color = inactivePlayerColor;
            OplayerOption.interactable = true;

        }


        //Adds a listener to the name input fields and invokes a method when the value changes. This is a callback.
        player1InputField.onValueChanged.AddListener(delegate { OnPlayer1NameChanged(); });
        player2InputField.onValueChanged.AddListener(delegate { OnPlayer2NameChanged(); });

        // Set the default values to what tthe inputField text is
        player1Name = player1InputField.text;
        player2Name = player2InputField.text;
    }

    /// <summary>
    /// Called at the end of every turn to check for win conditions
    /// Hardcoded all possible win conditions (8)
    /// We just take position of tiles and check the neighbours (within a row)
    /// 
    /// Tiles are numbered 0..8 from left to right, row by row, example:
    /// [0][1][2]
    /// [3][4][5]
    /// [6][7][8]
    /// </summary>
    public void EndTurn()
    {
        moveCount++;
        if (tileList[0].text == playerTurn && tileList[1].text == playerTurn && tileList[2].text == playerTurn) GameOver(playerTurn);
        else if (tileList[3].text == playerTurn && tileList[4].text == playerTurn && tileList[5].text == playerTurn) GameOver(playerTurn);
        else if (tileList[6].text == playerTurn && tileList[7].text == playerTurn && tileList[8].text == playerTurn) GameOver(playerTurn);
        else if (tileList[0].text == playerTurn && tileList[3].text == playerTurn && tileList[6].text == playerTurn) GameOver(playerTurn);
        else if (tileList[1].text == playerTurn && tileList[4].text == playerTurn && tileList[7].text == playerTurn) GameOver(playerTurn);
        else if (tileList[2].text == playerTurn && tileList[5].text == playerTurn && tileList[8].text == playerTurn) GameOver(playerTurn);
        else if (tileList[0].text == playerTurn && tileList[4].text == playerTurn && tileList[8].text == playerTurn) GameOver(playerTurn);
        else if (tileList[2].text == playerTurn && tileList[4].text == playerTurn && tileList[6].text == playerTurn) GameOver(playerTurn);
        else if (moveCount >= 9) GameOver("D");
        else
            ChangeTurn();
    }

    /// <summary>
    /// Changes the internal tracker for whos turn it is
    /// </summary>
    public void ChangeTurn()
    {
        // This is called a Ternary operator which evaluates "X" and results in "O" or "X" based on truths
        // We then just change some ui feedback like colors.
        playerTurn = (playerTurn == "X") ? "O" : "X";
        if (playerTurn == "X")
        {
            playerXIcon.color = activePlayerColor;
            playerOIcon.color = inactivePlayerColor;

            XplayerOption.interactable = true;
            OplayerOption.interactable = false;

            XplayerOption.GetComponent<Image>().color = activePlayerColor;
            OplayerOption.GetComponent<Image>().color = inactivePlayerColor;

            previousPlayerTurn = "O";

        }
        else
        {
            playerXIcon.color = inactivePlayerColor;
            playerOIcon.color = activePlayerColor;

            XplayerOption.interactable = false;
            OplayerOption.interactable = true;

            XplayerOption.GetComponent<Image>().color = inactivePlayerColor;
            OplayerOption.GetComponent<Image>().color = activePlayerColor;

            previousPlayerTurn = "X";

            if (gameType == GameType.Pvc)
            {
               StartCoroutine(ComputerPlay());
            }
        }

    }

    IEnumerator ComputerPlay()
    {
        yield return new WaitForSeconds(.2f);

        List<Text> availableTiles = new List<Text>();

        int checkWinPlay = CheckForComputerWin();

        int checkNotLosePlay = CheckForPlayerWin();

        print("checkWinPlay " + checkWinPlay);
        print("checkNotLosePlay " + checkNotLosePlay);


        if (checkWinPlay != -1 && !tileList[checkWinPlay].transform.GetComponentInParent<TileController>().used)
        {
            print("play to win");
            tileList[checkWinPlay].transform.GetComponentInParent<TileController>().UpdateTile();
        }
        else if(checkNotLosePlay != -1 && Random.Range(0, 100) >= 65 && !tileList[checkNotLosePlay].transform.GetComponentInParent<TileController>().used)
        {
            print("play to note lose");

            tileList[checkNotLosePlay].transform.GetComponentInParent<TileController>().UpdateTile();
  
        }
        else
        {
            foreach (Text item in tileList)
            {
                if (item.text == "")
                {
                    availableTiles.Add(item);
                }
            }
            int randPlay = Random.Range(0, availableTiles.Count - 1);
            availableTiles[randPlay].transform.GetComponentInParent<TileController>().UpdateTile();
        }


    }

    private int CheckForComputerWin()
    {
        if (tileList[0].text == playerTurn && tileList[1].text == playerTurn && tileList[2].text != playerTurn) return 2;
        else if(tileList[0].text == playerTurn && tileList[1].text != playerTurn && tileList[2].text == playerTurn) return 1;
        else if (tileList[0].text != playerTurn && tileList[1].text == playerTurn && tileList[2].text == playerTurn) return 0;
        
        else if(tileList[3].text == playerTurn && tileList[4].text == playerTurn && tileList[5].text != playerTurn) return 5;
        else if (tileList[3].text == playerTurn && tileList[4].text != playerTurn && tileList[5].text == playerTurn) return 4;
        else if (tileList[3].text != playerTurn && tileList[4].text == playerTurn && tileList[5].text == playerTurn) return 3;

        else if (tileList[6].text == playerTurn && tileList[7].text == playerTurn && tileList[8].text != playerTurn) return 8;
        else if (tileList[6].text == playerTurn && tileList[7].text != playerTurn && tileList[8].text == playerTurn) return 7;
        else if (tileList[6].text != playerTurn && tileList[7].text == playerTurn && tileList[8].text == playerTurn) return 6;

        else if (tileList[0].text == playerTurn && tileList[3].text == playerTurn && tileList[6].text != playerTurn) return 6;
        else if (tileList[0].text == playerTurn && tileList[3].text != playerTurn && tileList[6].text == playerTurn) return 3;
        else if (tileList[0].text != playerTurn && tileList[3].text == playerTurn && tileList[6].text == playerTurn) return 0;

        else if (tileList[1].text == playerTurn && tileList[4].text == playerTurn && tileList[7].text != playerTurn) return 7;
        else if (tileList[1].text == playerTurn && tileList[4].text != playerTurn && tileList[7].text == playerTurn) return 4;
        else if (tileList[1].text != playerTurn && tileList[4].text == playerTurn && tileList[7].text == playerTurn) return 1;

        else if (tileList[2].text == playerTurn && tileList[5].text == playerTurn && tileList[8].text != playerTurn) return 8;
        else if (tileList[2].text == playerTurn && tileList[5].text != playerTurn && tileList[8].text == playerTurn) return 5;
        else if (tileList[2].text != playerTurn && tileList[5].text == playerTurn && tileList[8].text == playerTurn) return 2;

        else if (tileList[0].text == playerTurn && tileList[4].text == playerTurn && tileList[8].text != playerTurn) return 8;
        else if (tileList[0].text == playerTurn && tileList[4].text != playerTurn && tileList[8].text == playerTurn) return 4;
        else if (tileList[0].text != playerTurn && tileList[4].text == playerTurn && tileList[8].text == playerTurn) return 0;

        else if (tileList[2].text == playerTurn && tileList[4].text == playerTurn && tileList[6].text != playerTurn) return 6;
        else if (tileList[2].text == playerTurn && tileList[4].text != playerTurn && tileList[6].text == playerTurn) return 4;
        else if (tileList[2].text != playerTurn && tileList[4].text == playerTurn && tileList[6].text == playerTurn) return 2;

        return -1;
    }


    private int CheckForPlayerWin()
    {
        if (tileList[0].text == previousPlayerTurn && tileList[1].text == previousPlayerTurn && tileList[2].text != previousPlayerTurn) return 2;
        else if (tileList[0].text == previousPlayerTurn && tileList[1].text != previousPlayerTurn && tileList[2].text == previousPlayerTurn) return 1;
        else if (tileList[0].text != previousPlayerTurn && tileList[1].text == previousPlayerTurn && tileList[2].text == previousPlayerTurn) return 0;

        else if (tileList[3].text == previousPlayerTurn && tileList[4].text == previousPlayerTurn && tileList[5].text != previousPlayerTurn) return 5;
        else if (tileList[3].text == previousPlayerTurn && tileList[4].text != previousPlayerTurn && tileList[5].text == previousPlayerTurn) return 4;
        else if (tileList[3].text != previousPlayerTurn && tileList[4].text == previousPlayerTurn && tileList[5].text == previousPlayerTurn) return 3;

        else if (tileList[6].text == previousPlayerTurn && tileList[7].text == previousPlayerTurn && tileList[8].text != previousPlayerTurn) return 8;
        else if (tileList[6].text == previousPlayerTurn && tileList[7].text != previousPlayerTurn && tileList[8].text == previousPlayerTurn) return 7;
        else if (tileList[6].text != previousPlayerTurn && tileList[7].text == previousPlayerTurn && tileList[8].text == previousPlayerTurn) return 6;

        else if (tileList[0].text == previousPlayerTurn && tileList[3].text == previousPlayerTurn && tileList[6].text != previousPlayerTurn) return 6;
        else if (tileList[0].text == previousPlayerTurn && tileList[3].text != previousPlayerTurn && tileList[6].text == previousPlayerTurn) return 3;
        else if (tileList[0].text != previousPlayerTurn && tileList[3].text == previousPlayerTurn && tileList[6].text == previousPlayerTurn) return 0;

        else if (tileList[1].text == previousPlayerTurn && tileList[4].text == previousPlayerTurn && tileList[7].text != previousPlayerTurn) return 7;
        else if (tileList[1].text == previousPlayerTurn && tileList[4].text != previousPlayerTurn && tileList[7].text == previousPlayerTurn) return 4;
        else if (tileList[1].text != previousPlayerTurn && tileList[4].text == previousPlayerTurn && tileList[7].text == previousPlayerTurn) return 1;

        else if (tileList[2].text == previousPlayerTurn && tileList[5].text == previousPlayerTurn && tileList[8].text != previousPlayerTurn) return 8;
        else if (tileList[2].text == previousPlayerTurn && tileList[5].text != previousPlayerTurn && tileList[8].text == previousPlayerTurn) return 5;
        else if (tileList[2].text != previousPlayerTurn && tileList[5].text == previousPlayerTurn && tileList[8].text == previousPlayerTurn) return 2;

        else if (tileList[0].text == previousPlayerTurn && tileList[4].text == previousPlayerTurn && tileList[8].text != previousPlayerTurn) return 8;
        else if (tileList[0].text == previousPlayerTurn && tileList[4].text != previousPlayerTurn && tileList[8].text == previousPlayerTurn) return 4;
        else if (tileList[0].text != previousPlayerTurn && tileList[4].text == previousPlayerTurn && tileList[8].text == previousPlayerTurn) return 0;

        else if (tileList[2].text == previousPlayerTurn && tileList[4].text == previousPlayerTurn && tileList[6].text != previousPlayerTurn) return 6;
        else if (tileList[2].text == previousPlayerTurn && tileList[4].text != previousPlayerTurn && tileList[6].text == previousPlayerTurn) return 4;
        else if (tileList[2].text != previousPlayerTurn && tileList[4].text == previousPlayerTurn && tileList[6].text == previousPlayerTurn) return 2;

        return -1;
    }




    /// <summary>
    /// Called when the game has found a win condition or draw
    /// </summary>
    /// <param name="winningPlayer">X O D</param>
    private void GameOver(string winningPlayer)
    {
        switch (winningPlayer)
        {
            case "D":
                winnerText.text = "DRAW";
                break;
            case "X":
                winnerText.text = player1Name;
                break;
            case "O":
                winnerText.text = player2Name;
                break;
        }
        XplayerOption.interactable = false;
        OplayerOption.interactable = false;

        aS.PlayOneShot(endSound);

        //endGameState.SetActive(true);
        ToggleButtonState(false);
    }

    /// <summary>
    /// Restarts the game state
    /// </summary>
    public void RestartGame()
    {
        // Reset some gamestate properties
        moveCount = 0;
        playerTurn = whoPlaysFirst;
        ToggleButtonState(true);
        //endGameState.SetActive(false);

        // Loop though all tiles and reset them
        for (int i = 0; i < tileList.Length; i++)
        {
            tileList[i].GetComponentInParent<TileController>().ResetTile();
        }

        playerTurn = whoPlaysFirst;
        if (playerTurn == "X")
        {
            XplayerOption.GetComponent<Image>().color = activePlayerColor;
            OplayerOption.GetComponent<Image>().color = inactivePlayerColor;
            playerOIcon.color = inactivePlayerColor;
            XplayerOption.interactable = true;
        }
        else
        {
            XplayerOption.GetComponent<Image>().color = inactivePlayerColor;
            OplayerOption.GetComponent<Image>().color = activePlayerColor;
            playerXIcon.color = inactivePlayerColor;
            OplayerOption.interactable = true;

        }


        //Adds a listener to the name input fields and invokes a method when the value changes. This is a callback.
        player1InputField.onValueChanged.AddListener(delegate { OnPlayer1NameChanged(); });
        player2InputField.onValueChanged.AddListener(delegate { OnPlayer2NameChanged(); });

        // Set the default values to what tthe inputField text is
        player1Name = player1InputField.text;
        player2Name = player2InputField.text;
    }

    /// <summary>
    /// Enables or disables all the buttons
    /// </summary>
    private void ToggleButtonState(bool state)
    {
        for (int i = 0; i < tileList.Length; i++)
        {
            tileList[i].GetComponentInParent<Button>().interactable = state;
        }
    }

    /// <summary>
    /// Returns the current players turn (X / O)
    /// </summary>
    public string GetPlayersTurn()
    {
        return playerTurn;
    }

    /// <summary>
    /// Retruns the display sprite (X / 0)
    /// </summary>
    public Sprite GetPlayerSprite()
    {
        if (playerTurn == "X") return tilePlayerX;
        else return tilePlayerO;
    }

    /// <summary>
    /// Callback for when the P1_textfield is updated. We just update the string for Player1
    /// </summary>
    public void OnPlayer1NameChanged()
    {
        player1Name = player1InputField.text;
    }

    /// <summary>
    /// Callback for when the P2_textfield is updated. We just update the string for Player2
    /// </summary>
    public void OnPlayer2NameChanged()
    {
        player2Name = player2InputField.text;
    }
}
