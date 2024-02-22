namespace SimpleRPG.Scripts.Common.Interfaces
{
    public interface IUpdateHandler
    {
        public void UpdateHandler(float deltaTime);
    }

    public interface IFixedUpdateHandler
    {
        public void FixedUpdateHandler(float deltaTime);
    }
}
