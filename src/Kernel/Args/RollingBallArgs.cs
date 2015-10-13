using System.Drawing;

namespace Kernel.Args {

    public class RollingBallArgs : ImageArgs {
        public int WindowSize { get; set; }
        public Color OptimalColor { get; set; }
    }

}
