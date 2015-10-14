namespace Kernel {

    public class RgbPixel {
        public byte Red;
        public byte Green;
        public byte Blue;
        public override string ToString() {
            return $"R:{Red}, G:{Green}, B:{Blue}";
        }
    }

}
