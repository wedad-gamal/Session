namespace Session.Polymorphism
{
    class Overloading
    {
        public int sum(int number1, int number2)
        {
            return number1 + number2;
        }
        public double sum(double number1, int number2)
        {
            return number1 + number2;
        }
        public double sum(int number1, double number2)
        {
            return number1 + number2;
        }
        public double sum(double number1, double number2)
        {
            return number1 + number2;
        }
    }
}
