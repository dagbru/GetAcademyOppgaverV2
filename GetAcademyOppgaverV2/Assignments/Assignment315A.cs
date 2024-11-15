namespace GetAcademyOppgaverV2.Assignments;

public class Assignment315A : IAssignment
{
    public void Run()
    {
        var random = new Random();
        var number = random.Next(1, 100);

        var guessAttempts = 0;
        
        while (true)
        {
            Console.Write("Gjett et tall mellom 1 og 100: ");

            var guess = Console.ReadLine();
            var guessedNumber = Convert.ToInt32(guess);

            guessAttempts++;

            if (guessedNumber == number)
            {
                Console.WriteLine($"Du gjettet riktig på {guessAttempts} forsøk");
                break;
            }

            if (guessedNumber > number)
            {
                Console.WriteLine("For høyt");
            }
            else if (guessedNumber < number)
            {
                Console.WriteLine("For lavt");
            }
        }
    }
}