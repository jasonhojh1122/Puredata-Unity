

namespace PDElement
{
    public class Piano : Instument
    {

        static string presetBusPrefix = "U_PP-";

        public Piano(int id, LibPdInstance pdPatch, int presetCnt = 5) : base(id, pdPatch, presetCnt)
        {
            presetBusName = presetBusPrefix + id.ToString();
        }

    }
}