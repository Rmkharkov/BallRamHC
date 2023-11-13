using System.Threading;
using System.Threading.Tasks;

namespace Player
{
    public interface IBulletBallMoving
    {
        Task AsyncMovingTask(float speed, float moveTimeStamp, CancellationToken token);
    }
}