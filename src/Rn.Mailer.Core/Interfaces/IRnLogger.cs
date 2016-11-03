namespace Rn.Mailer.Core.Interfaces
{
    public interface IRnLogger
    {
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
    }

    public class RnLogger : IRnLogger
    {
        public void Debug(string message)
        {
            // swallow
        }

        public void Info(string message)
        {
            // swallow
        }

        public void Warn(string message)
        {
            // swallow
        }
    }
}
