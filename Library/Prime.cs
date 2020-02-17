using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Prime
    {
        //TODO: Переделать SearchUpTo в решето эратосфена. 
        private readonly List<int> _primes;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="Lib.Prime"/>
        /// </summary>
        public Prime()
        {
            _primes = new List<int>();
            _primes.Add(2);
            _primes.Add(3);
        }

        /// <summary>
        /// Добавление в список всех
        /// недостающих простых чисел меньше введенного.
        /// </summary>
        /// <param name="num">Граница</param>
        private void SearchUpTo(int num)
        {
            for (int i = _primes.Last() + 2; i <= num; i += 2)
            {
                bool flag = false;
                foreach (var item in _primes)
                {
                    if (item > Math.Sqrt(i)) break;
                    if (i % item == 0)
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    _primes.Add(i);
                }
            }
        }

        /// <summary>
        /// Расчитывает все простые числа меньше введенного включительно.
        /// </summary>
        /// <param name="num">Граница</param>
        /// <returns>Возвращает список простых чисел</returns>
        public List<int> AllPrimesUpTo(int num)
        {
            SearchUpTo(num);
            return _primes;
        }

        /// <summary>
        /// Расчитывает и возвращает наибольшее простое число,
        /// которое меньше или равно данному.
        /// </summary>
        /// <param name="num">Граница</param>
        /// <returns>Простое число</returns>
        public int PrimeUpTo(int num)
        {
            SearchUpTo(num);
            return _primes.FindLast(arg => arg <= num);
        }

        /// <summary>
        /// Проверяет является-ли число простым.
        /// </summary>
        /// <param name="num">Число, которое нужно проверить</param>
        /// <returns>возвращает значение типа <see cref="bool"/></returns>
        public bool IsPrime(int num)
        {
            SearchUpTo(num);
            return _primes.Contains(num);
        }

        /// <summary>
        /// Разбивает число на простые множители
        /// </summary>
        /// <param name="num">Число</param>
        /// <returns>Возвращает список множетелей</returns>
        public List<int> Factorization(int num)
        {
            SearchUpTo(num);
            List<int> factors = new List<int>();
            while (num != 1)
            {
                foreach (var item in _primes)
                {
                    if (num % item == 0)
                    {
                        do
                        {
                            factors.Add(item);
                            num /= item;
                        } while (num % item == 0);
                    }
                }
            }

            if (factors.Count == 0)
            {
                factors.Add(num);
            }

            return factors;
        }
    }
}