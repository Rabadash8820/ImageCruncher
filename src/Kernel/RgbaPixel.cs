namespace Kernel {

    public class  RgbaPixel : RgbPixel {
        public byte Alpha;
        public override string ToString() {
            return $"{base.ToString()}, A:{Alpha}";
        }
    }

}
