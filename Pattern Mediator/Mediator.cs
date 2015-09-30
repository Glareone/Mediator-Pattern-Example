using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Mediator
{    
    /// <summary>
    /// Посредник. С ним должен быть связан
    /// Composition Root (корень композиции). 
    /// В нем должна находиться логика конфигурирования IoC контейнера 
    /// или создание явного класса-посредника
    /// 
    /// Посредник оперирует конкретными исполнителями
    /// 
    /// В других реализациях он может и не знать о конкретных исполнителях,
    /// Но должен знать об астрактном исполнителе,который знает о конкретных исполнителях.
    /// </summary>
    public static class Mediator
    {

        /// <summary>
        /// Gets or sets the dictionary of executors.
        /// </summary>
        /// <value>
        /// The dictionary of executors.
        /// </value>
        private static readonly Dictionary<string, List<Executor>> DictionaryOfExecutors = new Dictionary<string, List<Executor>>();

        /// <summary>
        /// Adds the executor.
        /// </summary>
        /// <param name="nameOfConcreteMediator">The name of concrete mediator.</param>
        /// <param name="collectionOfExecutors">The collection of executors.</param>
        public static void AddExecutors(string nameOfConcreteMediator, List<Executor> collectionOfExecutors)
        {
            if (DictionaryOfExecutors.ContainsKey(nameOfConcreteMediator))
            {
                return;
            }

            DictionaryOfExecutors.Add(nameOfConcreteMediator,collectionOfExecutors);
        }

        /// <summary>
        /// Gets the executors.
        /// </summary>
        /// <param name="nameOfConcreteMediator">The name of concrete mediator.</param>
        /// <returns>collection of executors</returns>
        public static List<Executor> GetExecutors(string nameOfConcreteMediator)
        {
            return (from dictionaryPage in DictionaryOfExecutors where dictionaryPage.Key == nameOfConcreteMediator select dictionaryPage.Value).FirstOrDefault();
        }

        public static void DoAllByExecutors(string nameOfConcreteMediator)
        {
            if (DictionaryOfExecutors.ContainsKey(nameOfConcreteMediator))
            {
                List<Executor> listOfExecutors = DictionaryOfExecutors[nameOfConcreteMediator];

                foreach (var executor in listOfExecutors)
                {
                    executor.DoSomething();
                }
            }
        }
    }
}
