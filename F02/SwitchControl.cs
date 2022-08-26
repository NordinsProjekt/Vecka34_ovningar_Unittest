namespace F02
{
    public class SwitchControl
    {
        public int Temperature { private get; set; }
        public string StatusOnSwitch()
        {
            if (Temperature < 18) return "ON";
            if (Temperature >= 18 && Temperature <= 21) return "Temperature = accepted range";
            if (Temperature > 21) return "OFF";
            return "ERROR";
        }
    }
}