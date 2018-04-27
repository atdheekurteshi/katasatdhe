namespace CarRental.Services
{
    public class Calculate : ICalculate
    {
        public float width;
        public float height;
        private float _calculate;

        public Calculate()
        {
            
        }

        public float Calcualte()
        {
            float v = height * height;
            return v;
        }

    }
}