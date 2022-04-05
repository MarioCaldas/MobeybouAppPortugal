///-----------------------------------------------------------------
///   Class:          TileController
///   Description:    Updates information relative to this tile
///   Author:         VueCode
///   GitHub:         https://github.com/ivuecode/
///-----------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;

public class TileController : MonoBehaviour
{
    [Header("Component References")]
    public GameStateController gameController;                       // Reference to the gamecontroller
    public Button interactiveButton;                                 // Reference to this button
    public Text internalText;                                        // Reference to this Text

    public bool used;

    private void Start()
    {
        used = false;

        GetComponent<Image>().color = new Color(1, 1, 1, 0);

    }
    /// <summary>
    /// Called everytime we press the button, we update the state of this tile.
    /// The internal tracking for whos position (the text component) and disable the button
    /// </summary>
    public void UpdateTile()
    {
        if(!used)
        {
            internalText.text = gameController.GetPlayersTurn();
            interactiveButton.image.sprite = gameController.GetPlayerSprite();
            interactiveButton.interactable = false;
            gameController.EndTurn();

            GetComponent<Image>().color = new Color(1, 1, 1, 1);


            used = true;
        }

    }

    /// <summary>
    /// Resets the tile properties
    /// - text component
    /// - buttton image
    /// </summary>
    public void ResetTile()
    {
        internalText.text = "";
        interactiveButton.image.sprite = gameController.tileEmpty;

        used = false;
        GetComponent<Image>().color = new Color(1, 1, 1, 0);

    }

    public void OnMouseUp()
    {
        //gameController.dragController.ResetCurrentDrag();
        print("ata");
        if(gameController.dragController.GetCurrentDrag() != null && !used)
        {

            print("ata 11");
            internalText.text = gameController.GetPlayersTurn();
            interactiveButton.image.sprite = gameController.GetPlayerSprite();
            interactiveButton.interactable = false;
        
            gameController.EndTurn();

            gameController.dragController.ResetCurrentTile();
            gameController.dragController.ResetCurrentDrag();

            GetComponent<Image>().color = new Color(1,1,1,1);

            used = true;
        }

    }

    public void OnMouseOver()
    {
        if (gameController.dragController.GetCurrentDrag() != null && !used)
        {
            gameController.dragController.SetCurrentTile(this);
        }
    }

    public void OnMouseExit()
    {
        gameController.dragController.ResetCurrentTile();
    }
}