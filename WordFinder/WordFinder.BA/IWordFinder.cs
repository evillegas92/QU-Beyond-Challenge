using System.Collections.Generic;

namespace WordFinder.BL
{
    public interface IWordFinder
    {
        IEnumerable<string> Find(IEnumerable<string> wordStream);
    }
}
