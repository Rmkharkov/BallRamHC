﻿using UnityEngine.Events;

namespace Player
{
    public interface IBallsController
    {
        UnityEvent LostSourceBall { get; }
        UnityEvent BallArrivedToGarage { get; }
    }
}