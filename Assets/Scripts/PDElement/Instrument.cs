
namespace PDElement {

    public class Instument {
        protected LibPdInstance pdPatch;
        protected string presetBusName;
        protected int id;
        protected int presetCnt;
        protected int curPreset;

        public Instument(int id, LibPdInstance pdPatch, int presetCnt = 6) {
            this.id = id;
            this.pdPatch = pdPatch;
            this.presetCnt = presetCnt;
            curPreset = 0;
        }

        public void PlayNextPreset() {
            curPreset = (curPreset + 1) % presetCnt;
            if (curPreset == 0) curPreset += 1;
            PlayCurPreset();
        }

        public void PlayRandomPreset() {
            curPreset = UnityEngine.Random.Range(1, presetCnt);
            PlayCurPreset();
        }

        public void PlayPreset(int i) {
            curPreset = i;
            PlayCurPreset();
        }

        public void Stop() {
            curPreset = 0;
            PlayCurPreset();
        }

        public void PlayCurPreset() {
            pdPatch.SendFloat(presetBusName, curPreset);
        }
    }

}