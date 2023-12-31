﻿using UnityEngine.Events;

namespace Player
{
    public interface IBulletBallTrigger
    {
        UnityEvent HitEnemyEvent { get; }
        UnityEvent ArrivedToGarage { get; }
        void Growth(float percent);
        void ResetSize();
    }
}