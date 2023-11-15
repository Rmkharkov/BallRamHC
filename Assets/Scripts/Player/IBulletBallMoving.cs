using System.Threading;
using System.Threading.Tasks;

namespace Player
{
    public interface IBulletBallMoving
    {
        void Shoot(float forceFactor);
        void Stop();
        void ResetPosition();
    }
}