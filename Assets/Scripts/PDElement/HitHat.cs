

namespace PDElement
{
    public class HitHat : Instument
    {

        static string presetBusPrefix = "U_HHP-";

        public HitHat(int id, LibPdInstance pdPatch, int presetCnt = 5) : base(id, pdPatch, presetCnt)
        {
            presetBusName = presetBusPrefix + id.ToString();
        }

    }
}