namespace DoodleWorldServer {

    public class RandomService {

        Random rd;

        public RandomService() {}

        public void Init(int originSeed) {
            Random rdrd = new Random(originSeed);
            int seed = 0;
            for (int i = 0; i < 100; i++) {
                seed = rdrd.Next();
            }
            rd = new Random(seed);
            SDebug.Log($"RandomService seed: {seed}");
        }

        public int Next() {
            return rd.Next();
        }

    }

}