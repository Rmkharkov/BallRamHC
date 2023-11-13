namespace Enemy
{
    public interface IEnemyView
    {
        IEnemyGetHit EnemyGetHit { get; }
        IEnemyInfection EnemyInfection { get; }
        bool IsSick { get; }
        void Init();
    }
}