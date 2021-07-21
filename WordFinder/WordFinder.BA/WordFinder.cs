using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordFinder.BL
{
    public class WordFinder : IWordFinder
    {
        private readonly IEnumerable<string> _matrix;
        private readonly int _matrixLength;

        public WordFinder(IEnumerable<string> matrix)
        {
            if (!matrix?.Any() ?? true)
                throw new ArgumentException("The matrix cannot be null or empty.");
            _matrix = matrix;

            _matrixLength = _matrix.First().Length;
            if (_matrixLength > 64)
                throw new ArgumentException("The matrix length cannot exceed 64.");
        }

        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            List<string> wordsFound = new();
            (string flattenedRows, string flattenedColumns) = GetColumnsAndRowsFlattened(_matrix, _matrixLength);

            foreach (string word in wordStream)
            {
                if (word.Length > _matrixLength)
                    continue;
                if (flattenedRows.Contains(word, StringComparison.InvariantCultureIgnoreCase))
                {
                    wordsFound.Add(word);
                    continue;
                }
                if (flattenedColumns.Contains(word, StringComparison.InvariantCultureIgnoreCase))
                    wordsFound.Add(word);
            }
            return wordsFound;
        }

        private static (string, string) GetColumnsAndRowsFlattened(IEnumerable<string> matrix, int matrixLength)
        {
            int matrixSize = matrixLength * matrixLength;
            StringBuilder rowsResult = new(matrixSize);
            StringBuilder columnsResult = new(matrixSize);

            List<string> matrixList = matrix.ToList();
            StringBuilder columnBuilder = new (matrixLength);
            bool checkedAllRows = false;

            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    if (!checkedAllRows)
                    {
                        rowsResult.Append(matrixList[j]);
                        if (j == matrixLength - 1)
                            checkedAllRows = true;
                    }
                        
                    columnBuilder.Append(matrixList[j][i]);
                }
                columnsResult.Append(columnBuilder);
                columnBuilder.Remove(0, matrixLength);
            }
            return (rowsResult.ToString(), columnsResult.ToString());
        }
    }
}
