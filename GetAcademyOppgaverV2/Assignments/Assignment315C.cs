namespace GetAcademyOppgaverV2.Assignments;

public class Assignment315C : IAssignment
{
    public void Run()
    {
        var text = "Terje";
        var reversed = ReverseText(text);
    }

    private static string ReverseText(string text)
    {
        var characters = text.ToCharArray().Reverse();

        var reversedText = string.Empty;
        foreach (var character in characters)
        {
            reversedText += character;
        }

        return reversedText;
    }
}