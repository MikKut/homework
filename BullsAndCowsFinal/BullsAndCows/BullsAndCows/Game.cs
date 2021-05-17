using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class Game
    {
        private List<string> answers;
        private int counter = default;
        private BullsAndCows currentBullsAndCows;
        public Game()
        {
            GetAllAnswers();

            currentBullsAndCows = new BullsAndCows(0, 0);
            Console.WriteLine("Think out the four-digit number");
        }
        private void GetAllAnswers()
        {
            answers = new List<string>();

            for (int i = 0; i < 9999; i++)
            {
                var tempString = i.ToString().PadLeft(4, '0');

                if (tempString.Length < 4)
                    continue;

                answers.Add(tempString);
            }
        }

        public bool MakeMove()
        {
            counter++;

            Console.WriteLine($"Round №{counter}");

            string newAnswer;
            if (counter == 1)
                newAnswer = GetRandomAnswer();

            else
                newAnswer = GetOneAnswer();

            Console.WriteLine($"Answer options left:{answers.Count}");
            Console.WriteLine($"Answer is: {newAnswer}. Yes or no?");

            var playerAnswer = Asking();

            if (playerAnswer == "no")
            {
                Console.WriteLine("How many bulls?");
                var bulls = Console.ReadLine();

                Console.WriteLine("How many cows?");
                var cows = Console.ReadLine();
                currentBullsAndCows = new BullsAndCows(Convert.ToInt32(bulls), Convert.ToInt32(cows));
                DeleteBadAnswers(newAnswer);
                return true;
            }

            else
            {
                Console.WriteLine("Computer won");
                return false;
            }
        }

        private string GetRandomAnswer() => answers[new Random().Next(0, answers.Count)];

        private string Asking()
        {
            var playerAnswer = Console.ReadLine();

            while (playerAnswer.ToLower() != "yes" && playerAnswer.ToLower() != "no")
            {
                Console.WriteLine($"Say \"yes\" or \"no\"");

                playerAnswer = Console.ReadLine();
            }

            return playerAnswer;
        }

        public BullsAndCows GetQuantityBullsAndCows(string firstNumber, string secondNumber)
        {
            var bullsAndCows = new BullsAndCows(0, 0);

            var tempSecond = secondNumber;

            var tempFirst = firstNumber;


            for (int i = 0; i < firstNumber.Length; i++)
            {
                if (secondNumber.Contains(firstNumber[i]))
                {
                    if (firstNumber[i] == secondNumber[i])
                    {
                        var temp1 = tempFirst.ToCharArray().ToList();
                        temp1.RemoveAt(temp1.IndexOf(firstNumber[i]));

                        var temp2 = tempSecond.ToCharArray().ToList();
                        temp2.RemoveAt(temp2.IndexOf(firstNumber[i]));

                        tempFirst = new string(temp1.ToArray());

                        tempSecond = new string(temp2.ToArray());

                        bullsAndCows.Bulls++;
                    }
                }
            }

            for (int i = 0; i < tempFirst.Length; i++)
            {
                if (tempFirst.Contains(tempSecond[i]))
                {
                    bullsAndCows.Cows++;
                }
            }



            return bullsAndCows;
        }

        private void DeleteBadAnswers(string currentAnswer)
        {
            var tempAnswers = new List<string>(answers);

            foreach (var answer in tempAnswers)
            {
                var newBullsAndCows = GetQuantityBullsAndCows(answer, currentAnswer);

                if (!currentBullsAndCows.Equals(newBullsAndCows))
                    answers.Remove(answer);

            }
        }
        private int GetMoveCost(string supposedAnswer)
        {
            var priceBulls = 0;

            var priceCows = 0;

            foreach (var answer in answers)
            {
                var newBullsAndCows = GetQuantityBullsAndCows(answer, supposedAnswer);

                if (currentBullsAndCows.Bulls == currentBullsAndCows.Bulls)
                {
                    priceBulls++;
                }

                if (currentBullsAndCows.Cows == currentBullsAndCows.Cows)
                {
                    priceCows++;
                }
            }

            return priceBulls*10 + priceCows;
        }

        private string GetOneAnswer()
        {
            try
            {
                if (answers.Count == 1)
                {
                    return answers[0];
                }

                var tempAnswers = new List<string>(answers);

                var answer = answers.Select(ans => new { answer = ans, price = GetMoveCost(ans), rep = RepetitionsNumber(ans) }).OrderBy(ans => ans.price).OrderByDescending(ans => ans.rep).First().answer;

                return answer;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"You lied: \"{ex.Message}\", try again!");
                var gameManager = new GameManager(new Game());
                gameManager.Start();
                throw new Exception();
                
            }
        }

        public int RepetitionsNumber(string str)
        {
            var tempCharArray = str.ToCharArray().Distinct().ToArray();

            var count = new string(tempCharArray).Length;
            return count;
        }
    }
}
