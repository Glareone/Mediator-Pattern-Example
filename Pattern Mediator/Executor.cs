// -----------------------------------------------------------------------
// <copyright file="Executor.cs" company="LLamasoft">
// Copyright LLamasoft, 2015
// </copyright>
// ----------------------------------------------------------------------- 
namespace Pattern_Mediator
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Concrete executor
    /// Конкретный исполнитель
    /// </summary>
    public class Executor
    {
        #region Constructors and Destructors

        public Executor(string executorName, string executorPath, string executorDoSomething)
        {
            this.ExecutorName = executorName;
            this.ExecutorPath = executorPath;
            this.ExecutorDosomething = executorDoSomething;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Executor"/> class from being created.
        /// </summary>
        private Executor()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ExecutorDosomething.
        /// </summary>
        /// <value>
        /// The dosomething.
        /// </value>
        private string ExecutorDosomething { get; set; }

        /// <summary>
        /// Gets or sets the name of the executor.
        /// </summary>
        /// <value>
        /// The name of the executor.
        /// </value>
        private string ExecutorName { get; set; }

        /// <summary>
        /// Gets or sets the executor path.
        /// </summary>
        /// <value>
        /// The executor path.
        /// </value>
        private string ExecutorPath { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Does something.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1306:FieldNamesMustBeginWithLowerCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        public void DoSomething()
        {
            if (File.Exists(this.ExecutorPath))
            {
                File.Delete(this.ExecutorPath);
            }

            using (var fs = File.Create(this.ExecutorPath))
            {
                var info = new UTF8Encoding(true).GetBytes(string.Format("{0} : {1}, {2}", this.ExecutorName, ExecutorDosomething, DateTime.Now));

                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }

        #endregion
    }
}