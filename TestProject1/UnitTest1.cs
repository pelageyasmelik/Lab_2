using Lab_2.Dictionary;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void Dictionary_ShouldBeZeroElement() {
        var dictionary = new dictionary();
        Assert.Equal(dictionary.ListWords().Count, 0);
    }
    
    [Theory]
    [InlineData("new word")]
    [InlineData("new word 2")]
    [InlineData("new word 3")]
    public void Dictionary_ShouleBe_ReturnExpected(string word) {
        var dictionary = new dictionary();
        Word w = new Word(word, new List<string>());
        dictionary.AddNewWord(w);
        
        Assert.Equal(dictionary.ListWords().Count,1);
    }
    
    
    [Theory]
    [InlineData("new word")]
    [InlineData("new word 2")]
    [InlineData("new word 3")]
    public void AddNewWord_ShouldBe_ReturnExpected(string word) {
        var dictionary = new dictionary();
        //слово не было
        Assert.False(dictionary.checkWord(word));
        
        //добавим новое слово
        Word w = new Word(word, new List<string>());
        dictionary.AddNewWord(w); 

        Assert.Equal(dictionary.ListWords().Count,1);
    }
    
    [Fact]
    public void AddNewWord_ShouldBe_ReturnFales() {
        var dictionary = new dictionary();
        Word w = new Word("root", new List<string>{"suffix1"});
        dictionary.AddNewWord(w);
        Assert.Equal(dictionary.ListWords().Count,1);
        
        //слово уже было
        Assert.True(dictionary.checkWord("rootsuffix1"));
        
        //добавим новое слово
        dictionary.AddNewWord(w);

        Assert.Equal(dictionary.ListWords().Count,1);
    }

    [Fact]
    public void SameRoot_ShouldBe_ReturnExpected() {
        var dictionary = new dictionary();
        Word w1 = new Word("root", new List<string>{"suffix1"});
        Word w2 = new Word("root", new List<string>{"suffix2"});
        Word w3 = new Word("root", new List<string>{"suffix3"});
        dictionary.AddNewWord(w1);
        dictionary.AddNewWord(w2);
        dictionary.AddNewWord(w3);
        Assert.Equal(dictionary.ListWords().Count,3);
        
        //слово уже было
        Assert.True(dictionary.checkWord("rootsuffix1"));

        Assert.Equal(dictionary.SameRoot("rootsuffix1").Count,3);
    }
   
}