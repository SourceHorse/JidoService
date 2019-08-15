using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.Services
{
    interface ISimpleMessageService
    {
        /// <summary>
        /// Adds a simple message
        /// </summary>
        /// <param name="simpleMessage">The message</param>
        void AddMessage(SimpleMessage simpleMessage);
    }
}
