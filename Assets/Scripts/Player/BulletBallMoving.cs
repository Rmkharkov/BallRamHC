using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Player
{
    public class BulletBallMoving : MonoBehaviour, IBulletBallMoving
    {
        [SerializeField] private Transform targetTransf;
        private CancellationToken _token;
        
        public async Task AsyncMovingTask(float speed, float moveTimeStamp, CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetTransf.position, speed * moveTimeStamp);
                    await Task.Delay(TimeSpan.FromSeconds(moveTimeStamp), token);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}