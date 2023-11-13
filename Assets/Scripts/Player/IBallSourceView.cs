namespace Player
{
    public interface IBallSourceView
    {
        bool Decrease(float percent, float minimumScale);
        void ResetSize();
    }
}