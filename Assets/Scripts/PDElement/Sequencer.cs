

namespace PDElement
{
    public class Sequencer
    {

        static string toggleBusPrefix = "U_SQT-";
        static string speedBusPrefix = "U_SQS-";

        LibPdInstance pdPatch;
        string toggleBusName;
        string speedBusName;

        int id;

        public float speed;

        public Sequencer(int id, LibPdInstance pdPatch, float speed = 145)
        {
            this.id = id;
            this.speed = 145;
            this.pdPatch = pdPatch;
            toggleBusName = toggleBusPrefix + id.ToString();
            speedBusName = speedBusPrefix + id.ToString();
            SetSpeed(this.speed);
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
            pdPatch.SendFloat(speedBusName, speed);
        }

        public void Toggle(bool turnOn)
        {
            if (turnOn)
                pdPatch.SendFloat(toggleBusName, 1);
            else
                pdPatch.SendFloat(toggleBusName, 0);
        }

    }
}