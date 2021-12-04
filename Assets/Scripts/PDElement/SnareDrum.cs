

namespace PDElement
{
    public class SnareDrum : Instument
    {

        static string presetBusPrefix = "U_SDP-";

        public SnareDrum(int id, LibPdInstance pdPatch, int presetCnt = 5) : base(id, pdPatch, presetCnt)
        {
            presetBusName = presetBusPrefix + id.ToString();
        }

    }
}