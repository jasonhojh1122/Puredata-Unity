

namespace PDElement
{
    public class Sequencer
    {

        static string toggleBusPrefix = "U_SQT-";
        static string speedBusPrefix = "U_SQS-";
        string toggleBusName;
        string speedBusName;

        int id;

        public float speed;

        public Sequencer(int id, float speed = 145)
        {
            this.id = id;
            this.speed = 145;
            toggleBusName = toggleBusPrefix + id.ToString();
            speedBusName = speedBusPrefix + id.ToString();
            SetSpeed(this.speed);
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
            PDPlayer.Instance.PdPatch.SendFloat(speedBusName, speed);
        }

        public void Toggle(bool turnOn)
        {
            if (turnOn)
                PDPlayer.Instance.PdPatch.SendFloat(toggleBusName, 1);
            else
                PDPlayer.Instance.PdPatch.SendFloat(toggleBusName, 0);
        }

    }
}