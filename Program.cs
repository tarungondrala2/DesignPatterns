namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*SingleResponsibility singleResponsibility = new SingleResponsibility();
            singleResponsibility.Start();*/

            /*OpenClose openClose = new OpenClose();
            openClose.Start();*/

            LiskovSubstitution liskovSubstitution = new LiskovSubstitution();
            liskovSubstitution.Start();

            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
    }
}
