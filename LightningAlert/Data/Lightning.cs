namespace DTN_lightning_alert.Data
{
    public class Lightning
    {
        public int FlashType { get; set; }
        public double StrikeTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double PeakAmps { get; set; }
        public string Reserved { get; set; }
        public double IcHeight { get; set; }
        public double ReceivedTime { get; set; }
        public double NumberOfSensor { get; set; }
        public double Multiplicity { get; set; }
    }
}
