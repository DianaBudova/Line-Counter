using LineCounter.Models;

namespace LineCounter.Tests
{
    public class FileRepositoryTests
    {
        [Test]
        public void AddItem_AddTwoSimilarItems_OneItemExpected()
        {
            string path = "..\\..\\..\\ForTests\\TestFile.txt";
            FileItem item1 = new(path);
            FileItem item2 = new(path);

            FileRepository repository = new();
            repository.AddItem(item1);
            repository.AddItem(item2);

            Assert.IsTrue(repository.Collection.Count() == 1, $"Repository has {repository.Collection.Count()} items instead of 1 item");
        }
    }
}