using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const string CONST_HOLE = "Hole";
    public const string CONST_STAIRS = "Stairs";
    public const string CONST_REPAIRITEM = "RepairItem";
    public const string CONST_INSUMO = "Insumo";
    public const string CONST_NOVELO = "Novelo";
    public const string CONST_CLUE = "Clue";
    public const float CONST_TIMETODESTROY = 20;

    public bool gameOver = false;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
