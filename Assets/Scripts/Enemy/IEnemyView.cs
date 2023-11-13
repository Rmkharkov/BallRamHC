namespace Enemy
{
    public interface IEnemyView
    {
        IEnemyGetHit EnemyGetHit { get; }
        IEnemyInfection EnemyInfection { get; }
        void Init();
    }
}