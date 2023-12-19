using Lab_2.Dictionary;

namespace Lab_2.View;

public class View
{ 
    private readonly dictionary dictionary;

    public View(dictionary _dictionary) {
        dictionary = _dictionary ?? throw new AggregateException();
    }
    public void start() {
        while (true) {
            string word = Console.ReadLine();
            if (word == "q") break;
            dictionary.AddWord(word);
        }   
    }
}