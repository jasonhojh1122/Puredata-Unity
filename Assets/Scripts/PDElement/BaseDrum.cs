

namespace PDElement
{
    public class BaseDrum : Instument
    {

        static string presetBusPrefix = "U_BDP-";

        public BaseDrum(int id, LibPdInstance pdPatch, int presetCnt = 5) : base(id, pdPatch, presetCnt)
        {
            presetBusName = presetBusPrefix + id.ToString();
        }

    }
}