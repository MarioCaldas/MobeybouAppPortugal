using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    [SerializeField] private PlayerOption currentDrag;
    [SerializeField] private TileController currentTile;

    [SerializeField] private BttSoundController bttSound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentDrag(PlayerOption drag)
    {
        currentDrag = drag;
    }
    public void ResetCurrentDrag()
    {
        currentDrag.ResetDrag();
        currentDrag = null;
        bttSound.PlaySound();

    }
    public PlayerOption GetCurrentDrag()
    {
        return currentDrag;
    }

    public void SetCurrentTile(TileController tile)
    {
        currentTile = tile;
    }
    public void ResetCurrentTile()
    {
        currentTile = null;

    }
    public TileController GetCurrentTile()
    {
        return currentTile;
    }
}
