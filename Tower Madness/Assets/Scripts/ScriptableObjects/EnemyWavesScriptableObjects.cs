using System;
using System.Collections.Generic;
using UnityEngine;

// TO create new one, just right click on any folder and check "GamePlay ScriptableObjects->Enemy Wave Settings"
//TODO Still not fully implemented 
[CreateAssetMenu(menuName = "Gameplay Scriptable Objects/Enemy Wave Settings ")]
public class EnemyWavesScriptableObjects : ScriptableObject
{
    [Serializable]
    public class EnemyWave
    {
        public int BasicEnemyCount;
        public int EliteEnemyCount;
        public int BossEnemyCount;

        public int WaveTimeLength;
    }

    public List<EnemyWave> EnemyWaves = new List<EnemyWave>();
}