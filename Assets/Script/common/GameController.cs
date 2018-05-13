using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static int GetRequireExpByLevel(int level) {
        //等差数列
        return (int)((level - 1) * (100f + (100f + 10f * (level - 2f))) / 2);
    }
}
