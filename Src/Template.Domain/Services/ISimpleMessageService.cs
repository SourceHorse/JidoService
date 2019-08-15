﻿using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.Services
{
    public interface ISimpleMessageService
    {
        /// <summary>
        /// Adds a simple message
        /// </summary>
        /// <param name="simpleMessage">The message</param>
        SimpleMessage AddMessage(SimpleMessage simpleMessage);

        /// <summary>
        /// Retrieves a message
        /// </summary>
        /// <param name="id">The message id</param>
        SimpleMessage RetrieveMessage(Guid id);
    }
}