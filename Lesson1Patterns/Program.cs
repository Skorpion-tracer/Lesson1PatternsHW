using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            MathGame mathGame = new MathGame();
            Console.ReadLine();
        }
    }

    public class MathGame
    {
        #region Fields
        private readonly string _greetingLine = "Здравствуйте! Вас приветствует математическая игра!";
        private readonly string _request = "Пожалуйста введите число.";
        private readonly string _errorMessage = "Необходимо вводить только целые числа!";
        #endregion

        #region Constructor
        public MathGame()
        {
            Game();
        }
        #endregion

        #region Private Methods
        private void Game()
        {
            Console.WriteLine(_greetingLine);
            Console.WriteLine(_request);

            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int result))
            {
                new Factorial(result);
                new SumNumbers(result);
                new MaxEven(result);
            }
            else
            {
                Console.WriteLine(_errorMessage);
                return;
            }
        } 
        #endregion
    }

    public class Factorial : BaseMathCaluculate
    {
        #region Constructor
        public Factorial(int userInput)
        {
            NumberResult = 1;
            UserInput = userInput;
            CalculateResult();
        }
        #endregion

        #region Methods
        protected override void CalculateResult()
        {
            for (int i = 1; i <= UserInput; i++)
            {
                try
                {
                    long result = checked(NumberResult *= i);
                }
                catch(ArithmeticException ex)
                {
                    Console.WriteLine($"Факториал числа {UserInput} невозможно расчитать!\nРезультат более {long.MaxValue.ToString("0,0", CultureInfo.CreateSpecificCulture("el-GR"))}.\n{ex.Message}");
                    return;
                }
            }            
            Console.WriteLine($"Факториал числа {UserInput} равен: {NumberResult}");
        }
        #endregion
    }

    public class MaxEven : BaseMathCaluculate
    {
        #region Constructor
        public MaxEven(int userInput)
        {
            NumberResult = 0;
            UserInput = userInput;
            CalculateResult();
        }
        #endregion

        #region Methods
        protected override void CalculateResult()
        {
            for (int i = 1; i <= UserInput; i++)
            {
                if (i % 2 == 0)
                {
                    NumberResult = i;
                }
            }

            Console.WriteLine($"Максимальное четное число меньше {UserInput} равно: {NumberResult}");
        }
        #endregion
    }

    public class SumNumbers : BaseMathCaluculate
    {
        #region Constructor
        public SumNumbers(int userInput)
        {
            NumberResult = 0;
            UserInput = userInput;
            CalculateResult();
        }
        #endregion

        #region Methods
        protected override void CalculateResult()
        {
            for (int i = 1; i <= UserInput; i++)
            {
                NumberResult += i;
            }

            Console.WriteLine($"Сумма от 1 до {UserInput} равна: {NumberResult}");
        } 
        #endregion
    }

    public abstract class BaseMathCaluculate
    {
        protected long NumberResult { get; set; }
        protected int UserInput { get; set; }
        protected abstract void CalculateResult();
    }
}
