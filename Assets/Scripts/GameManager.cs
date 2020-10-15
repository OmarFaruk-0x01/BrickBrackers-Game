using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    // Start is called before the first frame update

    // Blocks Section - Start -

    public static bool isBallMoving = false;
    public static int NormalBlockLife = 1;
    public static int BrickableBlockLife = 2;
    public static int FreezedBlockLife = 3;
    public static int BallHItValue = 1;
    public static float BallBaseSizeX = .25f;
    public static float BallBaseSizeY = .25f;
    public static float BallSizeY = BallBaseSizeX;
    public static float BallSizeX = BallBaseSizeY;
    public static float BarBaseSizeX = .5f;
    public static float BarBaseSizeY = .5f;
    public static float BarSizeY = BarBaseSizeX;
    public static float BarSizeX = BarBaseSizeY;
    public static int CurrentLevel = 1;
}
