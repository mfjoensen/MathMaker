namespace MathMaker
{
    public class MathMaker
    {
        /// <summary>
        /// Generate a list of math problems of the form "x + y".
        /// </summary>
        /// <param name="amount">Number of problems generated.</param>
        /// <param name="maxNumberLeft">Maximum possible integer of "x" in "x + y".</param>
        /// <param name="maxNumberRight">Maximum possible integer of "y" in "x + y".</param>
        /// <returns>List of generated math problems.</returns>
        public static List<string> MakePlus(int amount, int maxNumberLeft, int maxNumberRight)
        {
            Random random = new Random();
            List<string> problems = new();

            // Sets amount to the number of possible unique problems if it is above this, to avoid an endless loop.
            if (amount > maxNumberLeft * maxNumberRight)
            {
                amount = maxNumberLeft * maxNumberRight;
            }

            for (int i = 0; i < amount; i++)
            {               
                int leftNumber = 0;
                int rightNumber = 0;

                string problem = "Error";

                bool isUnique = false;

                // Loops until a problem is generated that is not currently present in the current list of problems
                while (!isUnique)
                {
                    leftNumber = random.Next(0, maxNumberLeft) + 1;
                    rightNumber = random.Next(0, maxNumberRight) + 1;

                    problem = leftNumber + " + " + rightNumber + " =";

                    if (!problems.Contains(problem))
                    {
                        isUnique = true;
                    }
                }                           

                problems.Add(problem);
            }

            return problems;
        }

        public static List<string> MakeMinus(int amount, int maxNumberLeft, int maxNumberRight, bool negResults, bool borrowAllowed)
        {
            Random random = new Random();
            List<string> problems = new();

            // Sets amount to the number of possible unique problems if it is above this, to avoid an endless loop.
            int maxAllowed = maxNumberLeft * maxNumberRight;

            if (!negResults)
            {
                maxAllowed = maxAllowed - (maxAllowed / 3) + 1;
            }

            if (!borrowAllowed)
            {
                maxAllowed = maxAllowed - (maxAllowed / 3);
            }

            if (amount > maxAllowed)
            {
                amount = maxAllowed;
            }

            // Loops until a problem is generated that is not currently present in the current list of problems
            for (int i = 0; i < amount; i++)
            {
                int leftNumber = 0;
                int rightNumber = 0;

                string problem = "Error";

                bool isValid = false;

                while (!isValid)
                {
                    leftNumber = random.Next(0, maxNumberLeft) + 1;
                    rightNumber = random.Next(0, maxNumberRight) + 1;

                    string leftNumberString = leftNumber.ToString();
                    string rightNumberString = rightNumber.ToString();

                    problem = leftNumber + " - " + rightNumber + " =";

                    bool negResult = false;

                    if (leftNumber - rightNumber < 0)
                    {
                        negResult = true;
                    }

                    int lastLeftDigit = int.Parse(leftNumberString[leftNumberString.Length - 1].ToString());
                    int lastRightDigit = int.Parse(rightNumberString[rightNumberString.Length - 1].ToString());

                    bool borrows = false;
                    if (lastLeftDigit < lastRightDigit)
                    {
                        borrows = true;
                    }

                    if (!problems.Contains(problem))
                    {
                        isValid = true;

                        if ((negResult && !negResults) || (borrows && !borrowAllowed))
                        {
                            isValid = false;
                        }
                    }
                }

                problems.Add(problem);
            }

            return problems;
        }

    }
}
