
namespace PDElement {

    public class Instument {
        protected int presetCnt;
        protected int curPreset;
        protected string name;

        public Instument(string name, int presetCnt = 6) {
            this.name = name;
            this.presetCnt = presetCnt;
            curPreset = 0;
            PlayCurPreset();
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
            PDPlayer.Instance.PdPatch.SendFloat("UP_" + name, curPreset);
        }
    }

}